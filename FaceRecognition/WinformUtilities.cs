using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FaceRecognition
{
    public class WinformUtilities
    {
        public static Image OpenImageFile(string Title = "Abrir imagem(s) para treinamento")
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = Title;
            fdlg.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                return Bitmap.FromStream(fdlg.OpenFile());
            }
            else return null;
        }

        public static List<Image> OpenMultiImageFile(string Title = "Abrir imagem(s) para treinamento")
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = Title;
            fdlg.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            fdlg.Multiselect = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                List<Image> list = new List<Image>();
                foreach (string f in fdlg.FileNames)
                    list.Add(Image.FromFile(f));
                return list;
            }
            else return null;
        }

        public static string PromptForName(string caption, string text, Image img, string defaultName = "")
        {
            Form prompt = new Form()
            {
                Width = 200,
                Height = 300,
                Text = caption
            };
            Label textLabel = new Label()
            {
                Left = 10,
                Top = 20,
                Width = 160,
                Text = text
            };
            TextBox textBox = new TextBox()
            {
                Left = 10,
                Top = 50,
                Width = 110,
                Height = 40,
                TabIndex = 0,
                TabStop = true,
                Text = defaultName
            };
            PictureBox pictureBox = new PictureBox()
            {
                Left = 10,
                Top = 80,
                Width = 150,
                Height = 150,
                Image = img,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            Button confirmation = new Button()
            {
                Text = "Save",
                Left = 20,
                Width = 80,
                Top = 190,
                TabIndex = 1,
                TabStop = true
            };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(pictureBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            prompt.ShowDialog();
            return string.IsNullOrEmpty(textBox.Text) ? Guid.NewGuid().ToString() : textBox.Text;
        }

        private static readonly String _databasePath = Application.StartupPath + "/face_store.db";

        private static readonly String _trainerDataPath = Application.StartupPath + "/traineddata";

        private static readonly CascadeClassifier _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_alt2.xml");

        public static string TrainImage(Image img, string preName = "")
        {
            if (img == null) return "";
            using (var ImageFrame = new Image<Bgr, Byte>(new Bitmap(img)))
            {

                var _recognizerEngine = new RecognizerEngine(_databasePath, _trainerDataPath);

                if (ImageFrame == null)
                    return null;

                var grayframe = ImageFrame.Convert<Gray, byte>();

                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here

                //int faceIndex = 1;

                List<string> names = new List<string>();
                foreach (var face in faces)
                {
                    ImageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them
                    int predictedUserId;
                    Bitmap map = ImageFrame.Copy(face).Bitmap;
                    try
                    {
                        predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(map));
                        //Debug.WriteLine(predictedUserId);
                    }
                    catch { predictedUserId = -1; }
                    if (predictedUserId == -1)
                    {
                        string name = string.IsNullOrEmpty(preName) ? PromptForName("Identificação", "Identifique a pessoa", map) : preName;
                        saveAFace(map, name);
                        names.Add(name);
                    }
                    else
                    {
                        //proceed to documents library
                        IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);
                        var username = dataStore.GetUsername(predictedUserId);
                        if (username != String.Empty)
                        {
                            if (preName != username)
                            {
                                string name = PromptForName("Identificação", "Identifique a pessoa", map, username);
                                if (name != username && name != preName)
                                    saveAFace(map, name);
                                names.Add(name);
                            }
                        }
                        else
                        {
                            string name = string.IsNullOrEmpty(preName) ? PromptForName("Identificação", "Insira o nome da pessoa", map) : preName;
                            saveAFace(map, name);
                            names.Add(name);
                        }

                    }
                }
                return string.Join(",", names.ToArray());
            }
        }

        public static Image<Bgr, Byte> RecognizeImage(Image img)
        {
            if (img == null) return null;
            using (var ImageFrame = new Image<Bgr, Byte>(new Bitmap(img)))
            {

                var _recognizerEngine = new RecognizerEngine(_databasePath, _trainerDataPath);
                _recognizerEngine.TrainRecognizer();
                if ( ImageFrame == null )
                {
                    System.Windows.Forms.MessageBox.Show( "Nenhuma imagem fornecida." );
                }

                var grayframe = ImageFrame.Convert<Gray, byte>();

                var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here

                if (faces.Length == 0)
                {
                    System.Windows.Forms.MessageBox.Show( "Nenhum rosto foi identifcado." );
                }

                //int faceIndex = 1;
                foreach (var face in faces)
                {

                    ImageFrame.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them

                    int predictedUserId;

                    Bitmap map = ImageFrame.Copy(face).Bitmap;

                    try
                    {
                        predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(map));
                        //Debug.WriteLine(predictedUserId);
                    }
                    catch { predictedUserId = -1; }

                    if (predictedUserId == -1)
                    {
                        continue;
                    }
                    else
                    {
                        //proceed to documents library
                        IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);
                        var username = dataStore.GetUsername(predictedUserId);
                        if (username != String.Empty)
                        {
                            ImageFrame.Draw(username, new Point(face.X, face.Y), Emgu.CV.CvEnum.FontFace.HersheyPlain, 2, new Bgr(Color.Red), 2);
                        }
                    }
                }

                return ImageFrame.Copy();

            }
        }

        static string saveAFace(Bitmap ImageFrame, string name)
        {
            var faceToSave = new Image<Gray, byte>(ImageFrame);
            Byte[] file;
            IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);

            var username = string.IsNullOrEmpty(name) ? Guid.NewGuid().ToString() : name;
            var filePath = Application.StartupPath + String.Format("/{0}.bmp", username);
            faceToSave.ToBitmap().Save(filePath);
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            return dataStore.SaveFace(username, file);
        }
    }
}
