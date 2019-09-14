
//Multiple face detection and recognition in real time
//Using EmguCV cross platform .Net wrapper to the Intel OpenCV image processing library for C#.Net
//Original code by Sergio Andrés Guitérrez Rojas, "Serg3ant" for the delveloper comunity, Sergiogut1805@hotmail.com
//Using the DirectShowLib-2005 to get the camera device names: http://www.emgu.com/forum/viewtopic.php?f=7&t=3095
//Image DB sample code used from: http://www.codeproject.com/Articles/26679/Image-Viewer-User-Control-with-Preview-Capability
//ComboBox loading examples taken from: http://stackoverflow.com/questions/27610930/c-sharp-reading-a-complex-file-into-a-combobox
//Example of how to load a picture as a copy so it can be deleted without error: http://www.codeproject.com/Questions/492654/bc-dplusdeleteplusimagepluswhichplusisplusope
//Another combox example taken from: http://stackoverflow.com/questions/3063320/combobox-adding-text-and-value-to-an-item-no-binding-source
//code example to convert string to int: https://msdn.microsoft.com/en-us/library/bb397679.aspx 
//code example to file rename: http://www.codeproject.com/Questions/264705/File-Rename-in-Csharp-net
//This version developed by Dafer Kiny, daferkiny1991@gmail.com and Justin Ratliff of http://www.J2RScientific.com 
//Last modified 5/6/2015

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Media;
using System.Net.Sockets;
using DirectShowLib;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace MultiFaceRec
{
    public partial class FrmPrincipal : Form
    {
        //Declararation of all variables, vectors and haarcascades
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;
        bool blnDetection = false;
        bool blnRecognition = false;
        bool blnRecSetting = false;
        private int _CameraIndex;
        bool blnSelect = false;
        int intCurrentFace;
        string szFile;
        int intFaceName;
        List<string> strFaceList = new List<string>();
        string strPicVid;
        string strBrowseFileName;
        int intFaceCount;
        string strLastPictureNumber;
        int intFaceToDelete;
        string strLastPictureName;
        int intLastPictureName;
        bool ReLoad = false;


        public FrmPrincipal()
        {
            InitializeComponent();
            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            //eye = new HaarCascade("haarcascade_eye.xml");  //this is not used
            try
            {
                //Load of previus trainned faces and labels for each image
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;

                    for (int tf = 1; tf < NumLabels + 1; tf++)
                    {
                        LoadFaces = "face" + tf + ".bmp";
                        trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                        labels.Add(Labels[tf]);
                    }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add to DB Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_load_faces.Enabled = false;
                btn_delete_all.Enabled = false;
            }
        }



        void FrameGrabber(object sender, EventArgs e)
        {
            label3.Text = "0";
            NamePersons.Add("");

            //Get the current frame form capture device
            if (strPicVid == "Picture")
            {
                currentFrame = new Image<Bgr, Byte>(strBrowseFileName).Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            }
            if (strPicVid == "Video")
            {
                currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            }

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            if (blnDetection == true)
            {
                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    t = t + 1;
                    result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);

                    //This gets the face so it can be added to the db
                    if (blnRecSetting == false)
                    {
                        if (blnSelect == true)
                        {
                            imageBox1.Image = imageBox1.Image;
                            //this stops the FrameGrabber so that detection can end cleanly until the face is added to the db 
                            //or continue is selected
                            Application.Idle -= FrameGrabber;
                                if (strPicVid == "Video")
                                {
                                    grabber.Dispose();
                                }
                        }
                        else
                        {
                            imageBox1.Image = result;
                        }
                    }
                    else
                    {
                        imageBox1.Image = null;
                    }

                    if (blnRecognition == true)
                    {
                        if (trainingImages.ToArray().Length != 0)
                        {
                            //TermCriteria for face recognition with numbers of trained images like maxIteration
                            MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);
                            //Eigen face recognizer
                            EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                               trainingImages.ToArray(),
                               labels.ToArray(),
                               3000,
                               ref termCrit);
                            name = recognizer.Recognize(result);
                            //Draw the label for each face detected and recognized
                            currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                        }
                        NamePersons[t - 1] = name;
                        NamePersons.Add("");
                    }

                    //Set the number of faces detected on the scene
                    label3.Text = facesDetected[0].Length.ToString();

                }
                t = 0;

                //Names concatenation of persons recognized
                for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
                {
                    names = names + NamePersons[nnn] + ", ";
                }
            }
            //Show the faces procesed and recognized
            imageBoxFrameGrabber.Image = currentFrame;
            label4.Text = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();
        }


        void ReInitialize (object sender, EventArgs e)
        {
            //Load of previus trainned faces and labels for each image
            try
            {
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;
                LoadFaces = null;
                trainingImages.Clear();
                labels.Clear();

                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    labels.Add(Labels[tf]);
                }
            }
            catch
            {
                //do nothing
                //MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add to DB Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //Load of previus trainned faces and labels for each image
            Application.Idle -= new EventHandler(ReInitialize);
        }

        void ClearEditDB (object sender, EventArgs e)
        {
            //Clear edit database
            strFaceList.Clear();
            lb_face_count.Text = "";
            groupBox3.Enabled = false;
            btn_scroll_fwd.Enabled = false;
            btn_scroll_back.Enabled = false;
            btn_update_name.Enabled = false;
            btn_delete_face.Enabled = false;
            btn_delete_all.Enabled = false;
            tb_face_names.Enabled = false;
            tb_face_names.Text = "";
            pictureBox1.Image = null;
            intCurrentFace = 0;
            Application.Idle -= new EventHandler(ClearEditDB);
            if (ReLoad == true)
            {
                Application.Idle += new EventHandler(ReloadDB); 
            }
        }

        void ReloadDB(object sender, EventArgs e)
        {
             //reload the faces
             groupBox3.Enabled = true;
             btn_load_faces.PerformClick();
             MessageBox.Show("The faces have been reloaded", "DK Face Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             Application.Idle -= new EventHandler(ReloadDB); 
        }


        private void btn_Start_Click_1(object sender, EventArgs e)
        {
 
            //Start the capture device
            if (strPicVid == "Video")
            {
                //Initialize the capture device
                grabber = new Capture(_CameraIndex); //this way allow for a specific camera to be selected
                grabber.QueryFrame();
            }
            if (strPicVid == "Picture")
            {
                currentFrame = new Image<Bgr, Byte>(strBrowseFileName).Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                imageBoxFrameGrabber.Image = currentFrame;
            }

            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            btn_Start.Enabled = false;
            btn_detect.Enabled = true;
            btn_Stop.Enabled = true;
            btn_recognize.Enabled = true;
            //Clear the Edit DB settings
            Application.Idle += new EventHandler(ClearEditDB);
        }

        private void btn_detect_Click(object sender, EventArgs e)
        {
            //Initialize the Face Detection event
            blnDetection = true;
            btn_detect.Enabled = false;
            groupBox1.Enabled = true;
            btn_add_DB.Enabled = true;
            btn_continue.Enabled = false;
            btn_select.Enabled = true;
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            //Stop detection and camera
                if (strPicVid == "Video")
                {
                    Application.Idle -= FrameGrabber;
                    grabber.Dispose();
                }
                else
                {
                    Application.Idle -= FrameGrabber;
                }

            imageBox1.Image = null; //sets image to blank
            groupBox1.Enabled = false;
            label4.Text = "Nobody";
            label3.Text = "0";
            textBox1.Text = "Person's Name";
            btn_Start.Enabled = false;
            btn_detect.Enabled = false;
            btn_Stop.Enabled = false;
            btn_add_DB.Enabled = false;
            btn_recognize.Enabled = false;
            groupBox3.Enabled = true;
            blnDetection = false;
            blnRecognition = false;
            blnRecSetting = false;
            blnSelect = false;
            btn_select.Enabled = false;
            btn_continue.Enabled = false; 
            btn_load_faces.Enabled = true;
            btn_picture_mode.Enabled = true;
            btn_video_mode.Enabled = true;
            currentFrame = null;
            imageBoxFrameGrabber.Image = null;  //sets the image to blank
        }

        private void btn_add_DB_Click(object sender, EventArgs e)
        {
            //Add face to DB
            try
            {
                //Trained face counter
                ContTrain = ContTrain + 1;

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(textBox1.Text);

                //Show face added in gray scale
                //imageBox1.Image = TrainedFace;  //we want this used before adding to the db

                //Write the number of triained faces in a file text for further load
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");

                //Write the labels of triained faces in a file text for further load
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }

                MessageBox.Show(textBox1.Text + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //restart detection for adding faces if not in recognition mode
            if (blnRecSetting == false)
            {
                if (blnSelect == true)
                {
                    if (strPicVid == "Video")
                    {
                        btn_Stop.PerformClick();
                        btn_video_mode.PerformClick();
                        btn_Start.PerformClick();
                        btn_detect.PerformClick();
                    }
                    if (strPicVid == "Picture")
                    {
                        btn_Stop.PerformClick();
                    }
                }
            }

        }

        private void btn_recognize_Click(object sender, EventArgs e)
        {
            //Recognize face
            blnDetection = true;
            blnRecognition = true;
            btn_recognize.Enabled = false;
            btn_add_DB.Enabled = false;
            btn_detect.Enabled = false;
            imageBox1.Image = null; //sets image to blank
            groupBox1.Enabled = false;
            blnRecSetting = true;
            btn_add_DB.Enabled = false;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            btn_Start.Enabled = true;
            btn_detect.Enabled = false;
            btn_Stop.Enabled = false;
            btn_add_DB.Enabled = false;
            btn_recognize.Enabled = false;
            groupBox1.Enabled = false;
            btn_continue.Enabled = false;
            btn_scroll_fwd.Enabled = false;
            btn_scroll_back.Enabled = false;
            btn_update_name.Enabled = false;
            btn_delete_face.Enabled = false;
            tb_face_names.Enabled = false;
            btn_delete_all.Enabled = false;
            btn_browse.Enabled = false;
            btn_Start.Enabled = false;
        }


        private void cbCamIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-> Get the selected item in the combobox
            KeyValuePair<int, string> SelectedItem = (KeyValuePair<int, string>)cbCamIndex.SelectedItem;
            //-> Assign selected cam index to defined var
            _CameraIndex = SelectedItem.Key;
        }

        private void btn_refresh_camerlist_Click(object sender, EventArgs e)
        {
            //-> Create a List to store for ComboCameras
            List<KeyValuePair<int, string>> ListCamerasData = new List<KeyValuePair<int, string>>();
            //-> Find systems cameras with DirectShow.Net dll 
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            int _DeviceIndex = 0;
            foreach (DirectShowLib.DsDevice _Camera in _SystemCamereas)
            {
                ListCamerasData.Add(new KeyValuePair<int, string>(_DeviceIndex, _Camera.Name));
                _DeviceIndex++;
            }
            //-> clear the combobox
            cbCamIndex.DataSource = null;
            cbCamIndex.Items.Clear();
            //-> bind the combobox
            cbCamIndex.DataSource = new BindingSource(ListCamerasData, null);
            cbCamIndex.DisplayMember = "Value";
            cbCamIndex.ValueMember = "Key";
            //DirectShowLib-2005 must be added as a reference in the bin folder
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            blnSelect = true;
            btn_select.Enabled = false;
            if (strPicVid == "Video")
            {
              btn_continue.Enabled = true;
            }
            
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            //restart detection for adding faces if not in recognition mode
            if (strPicVid == "Video")
            {
                if (blnSelect == true)
                {
                    btn_Stop.PerformClick();
                    btn_video_mode.PerformClick();
                    btn_Start.PerformClick();
                    btn_detect.PerformClick();
                }
            }
            else
            {
                currentFrame = null;
                imageBoxFrameGrabber.Image = null;
                blnSelect = false;
                Application.Idle += FrameGrabber;
                btn_continue.Enabled = false;
                btn_select.Enabled = true;
            }

        }

        private void btn_load_faces_Click(object sender, EventArgs e)
        {
            try
            {
                //load the pictures of the faces, starting with the first one
                Image im = GetCopyImage(Application.StartupPath + "/TrainedFaces/face1.bmp");
                pictureBox1.Image = im;

                //set up variables and enable GUI
                intCurrentFace = 1;
                btn_scroll_fwd.Enabled = true;
                btn_scroll_back.Enabled = false;
                btn_update_name.Enabled = true;
                    btn_delete_face.Enabled = true;
                    //btn_delete_face.Enabled = false;
                tb_face_names.Enabled = true;
                btn_delete_all.Enabled = true;

                //open the text files with the stored names to read it 
                szFile = Application.StartupPath + "/TrainedFaces/TrainedLabels.txt";

                string[] lineOfContents = File.ReadAllLines(szFile);
                foreach (var line in lineOfContents)
                {
                    string[] tokens = line.Split('%');
                    foreach (var items in tokens)
                    {
                        strFaceList.Add(items);
                    }
                }

                //Display the number of trained faces
                lb_face_count.Text = strFaceList[0];
                lb_face_count.Visible = true;
                //this sets the text to display the name of the first image by default
                tb_face_names.Text = strFaceList[1];
                intFaceName = 1;
                btn_load_faces.Enabled = false;

            }
            catch
            {
                MessageBox.Show("No faces have been trained in the DB or files not found. Please add at least a face (train with the Add to DB Button).", "DK Face Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //This will clear anything that might have partially loaded if anything failed
                tb_face_names.Text = "";
                pictureBox1.Image = null;
                intCurrentFace = 0;
                btn_load_faces.Enabled = false;
                btn_delete_all.Enabled = false;
            }
        }

        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }

        private void btn_scroll_fwd_Click(object sender, EventArgs e)
        {
            try
            {
                intCurrentFace = intCurrentFace + 1;
                Image im = GetCopyImage(Application.StartupPath + "/TrainedFaces/face" + intCurrentFace + ".bmp");
                pictureBox1.Image = im;
                btn_scroll_back.Enabled = true;
                btn_scroll_fwd.Enabled = true;
                intFaceName = intFaceName + 1;
                tb_face_names.Text = strFaceList[intFaceName];
            }
            catch
            {
                MessageBox.Show("No more faces to show.", "DK Face Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_scroll_fwd.Enabled = false;
                btn_scroll_back.Enabled = true;
                intCurrentFace = intCurrentFace - 1;
            }
        }

        private void btn_scroll_back_Click(object sender, EventArgs e)
        {
            try
            {
                intCurrentFace = intCurrentFace - 1;
                Image im = GetCopyImage(Application.StartupPath + "/TrainedFaces/face" + intCurrentFace + ".bmp");
                pictureBox1.Image = im;

                btn_scroll_back.Enabled = true;
                btn_scroll_fwd.Enabled = true;
                intFaceName = intFaceName - 1;
                tb_face_names.Text = strFaceList[intFaceName];
            }
            catch
            {
                MessageBox.Show("No more faces to show.", "DK Face Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_scroll_back.Enabled = false;
                btn_scroll_fwd.Enabled = true;
                intCurrentFace = intCurrentFace + 1;
            }
        }

        private void btn_delete_face_Click(object sender, EventArgs e)
        {
            //need a solution to delete a numbered image file and reorder the remaing images so they remain in numberical order 1,2,3, etc.

            //if there is DesignOnlyAttribute 1 face, this uses the Delete all
            if (lb_face_count.Text == "1")
            {
                btn_delete_all.PerformClick();
            }
            else
            {

                DialogResult d = MessageBox.Show("Are you sure you want to delete this faces?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    //if there is more than one face trained
                    try
                    {
                        try//this will update the text file
                        {
                            strLastPictureNumber = strFaceList[0]; //sets the last picture number 
                            intFaceToDelete = intFaceName; //sets the number in the list of the face to delete

                            intLastPictureName = Int32.Parse(strLastPictureNumber); //changing the string to an int
                            strLastPictureName = strFaceList[intLastPictureName]; //sets the actual name

                            //This converts the face count stored as string from the list to an int so it can be subtracted by 1
                            intFaceCount = Convert.ToInt16(strFaceList[0]);
                            intFaceCount--;  //this does the subtraction of 1
                            strFaceList[0] = intFaceCount.ToString(); //this put the new value back in the string list

                            //Update the list with the new item
                            strFaceList[intFaceName] = strLastPictureName;

                            //this removes the last face name from the list //will need additional logic if last face is set to delete
                            strFaceList.RemoveAt(intLastPictureName);

                            //this deletes the file
                            File.Delete(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");

                            //this rewrites the files
                            using (var file = File.CreateText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt"))
                            {
                                foreach (var arr in strFaceList)
                                {
                                    file.Write(arr + "%");
                                }
                            }

                            //this removes any extra % at the end of the file            
                            FileStream fs = new FileStream(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", FileMode.Open, FileAccess.ReadWrite);
                            fs.SetLength(fs.Length - 1);
                            fs.Close();

                        }
                        catch
                        {
                            MessageBox.Show("Could not update face Db text file.", "DK Face Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        try//this will update the image file to remove it
                        {
                            //this deletes the picture image file
                            File.Delete(Application.StartupPath + "/TrainedFaces/face" + intCurrentFace + ".bmp");

                            //need to take last face and rename it for file we deleted

                            if (intLastPictureName != intFaceName)
                            {
                                File.Move(Application.StartupPath + "/TrainedFaces/face" + intLastPictureName + ".bmp", Application.StartupPath + "/TrainedFaces/face" + intCurrentFace + ".bmp");
                            }

                            //reset face db options
                            tb_face_names.Text = "";
                            pictureBox1.Image = null;
                            intCurrentFace = 0;
                            btn_load_faces.Enabled = true;
                            btn_delete_all.Enabled = false;
                            btn_update_name.Enabled = false;
                            btn_delete_face.Enabled = false;


                            //Clear the Edit DB settings
                            ReLoad = true;
                            Application.Idle += new EventHandler(ClearEditDB);

                        }
                        catch
                        {
                            MessageBox.Show("Could not update face Picture file.", "DK Face Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Delete face process failed.", "DK Face Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
             else if (d == DialogResult.No)
             {
               //Do nothing
             }
            }

        }

        private void btn_update_name_Click(object sender, EventArgs e)
        {
            //Update the list with the new item
            strFaceList[intFaceName] = tb_face_names.Text;

            //this deletes the file
            File.Delete(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");

            //this rewrites the files
            using (var file = File.CreateText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt"))
            {
                foreach (var arr in strFaceList)
                {
                    file.Write(arr + "%"); 
                }
            }

            //this removes any extra % at the end of the file  
            FileStream fs = new FileStream(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", FileMode.Open, FileAccess.ReadWrite);
            fs.SetLength(fs.Length - 1);
            fs.Close();

        }

        private void btn_delete_all_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure you want to delete all learned faces?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                ReLoad = false;
                try
                {
                    Array.ForEach(Directory.GetFiles(Application.StartupPath + "/TrainedFaces"), File.Delete);
                    //Clear the Edit DB settings
                    Application.Idle += new EventHandler(ClearEditDB);
                    MessageBox.Show("All faces have been deleted, you will need to restart the application.", "DK Face Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();

                }
                catch
                {
                    MessageBox.Show("This process failed.", "DK Face Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else if (d == DialogResult.No)
            {
                //Do nothing
            }
        }

        private void btn_picture_mode_Click(object sender, EventArgs e)
        {
            ReLoad = false;
            btn_browse.Enabled = true;
            btn_picture_mode.Enabled = false;
            btn_video_mode.Enabled = false;
            strPicVid = "Picture";
            //Clear the Edit DB settings
            Application.Idle += new EventHandler(ClearEditDB);
            //Load of previus trainned faces and labels for each image
            Application.Idle += new EventHandler(ReInitialize);
        }

        private void btn_video_mode_Click(object sender, EventArgs e)
        {
            ReLoad = false;
            btn_browse.Enabled = false;
            btn_video_mode.Enabled = false;
            btn_Start.Enabled = true;
            btn_picture_mode.Enabled = false;
            strPicVid = "Video";
            //Clear the Edit DB settings
            Application.Idle += new EventHandler(ClearEditDB);
            //Load of previus trainned faces and labels for each image
            Application.Idle += new EventHandler(ReInitialize);
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            DialogResult resDialog = openFileDialog1.ShowDialog();

            if (resDialog.ToString() == "OK")
            {
                strBrowseFileName = openFileDialog1.FileName;
                btn_Start.Enabled = true;
                btn_picture_mode.Enabled = false;
                btn_browse.Enabled = false;
            }
            else
            {
                btn_browse.Enabled = false;
                btn_picture_mode.Enabled = true;
                btn_video_mode.Enabled = true;
                strPicVid = "";
                groupBox3.Enabled = true;
                btn_load_faces.Enabled = true;
            }
        }

        
    }
}