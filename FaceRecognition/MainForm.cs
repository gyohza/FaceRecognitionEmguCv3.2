using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FaceRecognition
{
    public partial class MainForm : Form
    {
        System.ComponentModel.BackgroundWorker bckGroundTrainer = new System.ComponentModel.BackgroundWorker();

        public MainForm()
        {
            InitializeComponent();
            this.bckGroundTrainer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckGroundTrainer_DoWork);
            this.bckGroundTrainer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckGroundTrainer_RunWorkerCompleted);
        }


        private void bckGroundTrainer_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            e.Result = TrainRecognizer(worker, e);
        }

        private bool TrainRecognizer(BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                var hasTrainedRecognizer = _recognizerEngine.TrainRecognizer();
                return hasTrainedRecognizer;
            }
            return false;
        }

        private void bckGroundTrainer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                System.Windows.Forms.MessageBox.Show( "Treinamento cancelado." );
            }
            else
            {
                var result = (bool) e.Result;
            }
        }

        private CascadeClassifier _cascadeClassifier;
        private RecognizerEngine _recognizerEngine;
        private readonly String _databasePath = Application.StartupPath + "/face_store.db";
        private readonly String _trainerDataPath = Application.StartupPath + "/traineddata";
        private void MainForm_Load(object sender, EventArgs e)
        {
            _recognizerEngine = new RecognizerEngine(_databasePath, _trainerDataPath);
            bckGroundTrainer.RunWorkerAsync();
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_alt2.xml");
        }

        void saveAFace(Rectangle face, Bitmap ImageFrame)
        {
            var faceToSave = new Image<Gray, byte>(ImageFrame);
            Byte[] file;
            IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);

            var username = Guid.NewGuid().ToString();
            var filePath = Application.StartupPath + String.Format("/{0}.bmp", username);
            faceToSave.ToBitmap().Save(filePath);
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            var result = dataStore.SaveFace(username, file);
            bckGroundTrainer.RunWorkerAsync();
            MessageBox.Show(result, "Salvar resultado", MessageBoxButtons.OK);
        }

        void ClearTrainedFaces()
        {
            
            if (
                MessageBox.Show( "Essa é uma ação destrutiva.\n\nVocê tem certeza que deseja prosseguir?", "Confirmação", MessageBoxButtons.YesNo )
                    != DialogResult.Yes
            )
            {
                MessageBox.Show("Ação cancelada com êxito.");
                return;
            }

            IDataStoreAccess dataStore = new DataStoreAccess(_databasePath);

            dataStore.ClearTrainedFaces();

            foreach (var file in new DirectoryInfo(Application.StartupPath).GetFiles("*.bmp")) {
                file.Delete();
            }

            img.BackgroundImage = null;

            msg.Text = "Dados foram esvaziados da base.";
            msg.ForeColor = System.Drawing.Color.Black;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fromPictureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var img = WinformUtilities.OpenImageFile();
            try
            {
                var img1 = WinformUtilities.RecognizeImage(img);
                this.img.Image = img1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void clearTrainedDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTrainedFaces();
        }

        private void entrarToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var img = WinformUtilities.OpenImageFile();
            try
            {
                var img1 = WinformUtilities.RecognizeImage( img, msg );
                this.img.Image = img1;
            }
            catch ( Exception ex )
            {
                MessageBox.Show( ex.ToString() );
            }
        }

        private void cadastrarToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var imgs = WinformUtilities.OpenMultiImageFile();

            List<string> processed = new List<string>();

            if ( imgs == null )
                return;

            var unidentified = 0;

            var multiple = 0;

            foreach ( var img in imgs )
            {
                try
                {
                    processed.Add( WinformUtilities.TrainImage( img ) );
                }
                catch (Exception ex)
                {
                    if ( ex.Message == "no_faces" )
                        unidentified++;
                    else if ( ex.Message == "multiple_faces" )
                        multiple++;
                    else
                        MessageBox.Show(ex.Message);
                }
            }

            string regNames = String.Join( "\n", processed.Where( v => v.Length > 0 ) );

            MessageBox.Show(
                regNames.Length > 0 ?
                string.Format( "Imagens processadas:\n\n{0}\n\nImagens sem rosto identificado: {1}\nImagens com múltiplos rostos: {2}", regNames, unidentified, multiple)
                : "Nenhuma imagem válida processada."
            );
        }
    }

}
