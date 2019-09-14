namespace MultiFaceRec
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_continue = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_refresh_camerlist = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCamIndex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_detect = new System.Windows.Forms.Button();
            this.btn_add_DB = new System.Windows.Forms.Button();
            this.btn_recognize = new System.Windows.Forms.Button();
            this.btn_delete_face = new System.Windows.Forms.Button();
            this.btn_update_name = new System.Windows.Forms.Button();
            this.btn_scroll_back = new System.Windows.Forms.Button();
            this.btn_scroll_fwd = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_face_names = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_delete_all = new System.Windows.Forms.Button();
            this.lb_face_count = new System.Windows.Forms.Label();
            this.btn_load_faces = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_picture_mode = new System.Windows.Forms.Button();
            this.btn_video_mode = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 209);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Enter Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_continue);
            this.groupBox1.Controls.Add(this.btn_select);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.imageBox1);
            this.groupBox1.Location = new System.Drawing.Point(453, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(245, 298);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Training: ";
            // 
            // btn_continue
            // 
            this.btn_continue.Location = new System.Drawing.Point(134, 256);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(104, 35);
            this.btn_continue.TabIndex = 24;
            this.btn_continue.Text = "Continue";
            this.btn_continue.UseVisualStyleBackColor = true;
            this.btn_continue.Click += new System.EventHandler(this.btn_continue_Click);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(15, 256);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(104, 35);
            this.btn_select.TabIndex = 23;
            this.btn_select.Text = "Select";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 213);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name: ";
            // 
            // imageBox1
            // 
            this.imageBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBox1.Location = new System.Drawing.Point(15, 22);
            this.imageBox1.Margin = new System.Windows.Forms.Padding(4);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(217, 164);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBox1.TabIndex = 5;
            this.imageBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_refresh_camerlist);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbCamIndex);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(706, 38);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(279, 298);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results: ";
            // 
            // btn_refresh_camerlist
            // 
            this.btn_refresh_camerlist.Location = new System.Drawing.Point(60, 256);
            this.btn_refresh_camerlist.Name = "btn_refresh_camerlist";
            this.btn_refresh_camerlist.Size = new System.Drawing.Size(165, 35);
            this.btn_refresh_camerlist.TabIndex = 22;
            this.btn_refresh_camerlist.Text = "Refresh Camera List";
            this.btn_refresh_camerlist.UseVisualStyleBackColor = true;
            this.btn_refresh_camerlist.Click += new System.EventHandler(this.btn_refresh_camerlist_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 216);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Select Camera:";
            // 
            // cbCamIndex
            // 
            this.cbCamIndex.FormattingEnabled = true;
            this.cbCamIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbCamIndex.Location = new System.Drawing.Point(122, 213);
            this.cbCamIndex.Margin = new System.Windows.Forms.Padding(4);
            this.cbCamIndex.Name = "cbCamIndex";
            this.cbCamIndex.Size = new System.Drawing.Size(149, 24);
            this.cbCamIndex.TabIndex = 20;
            this.cbCamIndex.Text = "0";
            this.cbCamIndex.SelectedIndexChanged += new System.EventHandler(this.cbCamIndex_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Persons present in the scene:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(12, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Nobody";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(217, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Number of faces detected: ";
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(453, 353);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(104, 35);
            this.btn_Start.TabIndex = 10;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click_1);
            // 
            // btn_detect
            // 
            this.btn_detect.Location = new System.Drawing.Point(673, 353);
            this.btn_detect.Name = "btn_detect";
            this.btn_detect.Size = new System.Drawing.Size(104, 35);
            this.btn_detect.TabIndex = 11;
            this.btn_detect.Text = "Detect";
            this.btn_detect.UseVisualStyleBackColor = true;
            this.btn_detect.Click += new System.EventHandler(this.btn_detect_Click);
            // 
            // btn_add_DB
            // 
            this.btn_add_DB.Location = new System.Drawing.Point(783, 353);
            this.btn_add_DB.Name = "btn_add_DB";
            this.btn_add_DB.Size = new System.Drawing.Size(104, 35);
            this.btn_add_DB.TabIndex = 12;
            this.btn_add_DB.Text = "Add to DB";
            this.btn_add_DB.UseVisualStyleBackColor = true;
            this.btn_add_DB.Click += new System.EventHandler(this.btn_add_DB_Click);
            // 
            // btn_recognize
            // 
            this.btn_recognize.Location = new System.Drawing.Point(893, 353);
            this.btn_recognize.Name = "btn_recognize";
            this.btn_recognize.Size = new System.Drawing.Size(104, 35);
            this.btn_recognize.TabIndex = 13;
            this.btn_recognize.Text = "Recognize";
            this.btn_recognize.UseVisualStyleBackColor = true;
            this.btn_recognize.Click += new System.EventHandler(this.btn_recognize_Click);
            // 
            // btn_delete_face
            // 
            this.btn_delete_face.Location = new System.Drawing.Point(7, 222);
            this.btn_delete_face.Name = "btn_delete_face";
            this.btn_delete_face.Size = new System.Drawing.Size(109, 31);
            this.btn_delete_face.TabIndex = 14;
            this.btn_delete_face.Text = "Delete face";
            this.btn_delete_face.UseVisualStyleBackColor = true;
            this.btn_delete_face.Click += new System.EventHandler(this.btn_delete_face_Click);
            // 
            // btn_update_name
            // 
            this.btn_update_name.Location = new System.Drawing.Point(122, 222);
            this.btn_update_name.Name = "btn_update_name";
            this.btn_update_name.Size = new System.Drawing.Size(109, 31);
            this.btn_update_name.TabIndex = 15;
            this.btn_update_name.Text = "Update name";
            this.btn_update_name.UseVisualStyleBackColor = true;
            this.btn_update_name.Click += new System.EventHandler(this.btn_update_name_Click);
            // 
            // btn_scroll_back
            // 
            this.btn_scroll_back.Location = new System.Drawing.Point(37, 163);
            this.btn_scroll_back.Name = "btn_scroll_back";
            this.btn_scroll_back.Size = new System.Drawing.Size(75, 23);
            this.btn_scroll_back.TabIndex = 17;
            this.btn_scroll_back.Text = "<";
            this.btn_scroll_back.UseVisualStyleBackColor = true;
            this.btn_scroll_back.Click += new System.EventHandler(this.btn_scroll_back_Click);
            // 
            // btn_scroll_fwd
            // 
            this.btn_scroll_fwd.Location = new System.Drawing.Point(118, 163);
            this.btn_scroll_fwd.Name = "btn_scroll_fwd";
            this.btn_scroll_fwd.Size = new System.Drawing.Size(75, 23);
            this.btn_scroll_fwd.TabIndex = 18;
            this.btn_scroll_fwd.Text = ">";
            this.btn_scroll_fwd.UseVisualStyleBackColor = true;
            this.btn_scroll_fwd.Click += new System.EventHandler(this.btn_scroll_fwd_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_face_names);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btn_delete_all);
            this.groupBox3.Controls.Add(this.lb_face_count);
            this.groupBox3.Controls.Add(this.btn_load_faces);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.btn_delete_face);
            this.groupBox3.Controls.Add(this.btn_scroll_fwd);
            this.groupBox3.Controls.Add(this.btn_update_name);
            this.groupBox3.Controls.Add(this.btn_scroll_back);
            this.groupBox3.Location = new System.Drawing.Point(13, 353);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 257);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Edit Database:";
            // 
            // tb_face_names
            // 
            this.tb_face_names.Location = new System.Drawing.Point(28, 194);
            this.tb_face_names.Name = "tb_face_names";
            this.tb_face_names.Size = new System.Drawing.Size(180, 22);
            this.tb_face_names.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "Number of Trained Faces:";
            // 
            // btn_delete_all
            // 
            this.btn_delete_all.Location = new System.Drawing.Point(257, 222);
            this.btn_delete_all.Name = "btn_delete_all";
            this.btn_delete_all.Size = new System.Drawing.Size(109, 31);
            this.btn_delete_all.TabIndex = 23;
            this.btn_delete_all.Text = "Delete All";
            this.btn_delete_all.UseVisualStyleBackColor = true;
            this.btn_delete_all.Click += new System.EventHandler(this.btn_delete_all_Click);
            // 
            // lb_face_count
            // 
            this.lb_face_count.AutoSize = true;
            this.lb_face_count.Location = new System.Drawing.Point(289, 102);
            this.lb_face_count.Name = "lb_face_count";
            this.lb_face_count.Size = new System.Drawing.Size(46, 17);
            this.lb_face_count.TabIndex = 26;
            this.lb_face_count.Text = "label6";
            this.lb_face_count.Visible = false;
            // 
            // btn_load_faces
            // 
            this.btn_load_faces.Location = new System.Drawing.Point(257, 33);
            this.btn_load_faces.Name = "btn_load_faces";
            this.btn_load_faces.Size = new System.Drawing.Size(109, 31);
            this.btn_load_faces.TabIndex = 20;
            this.btn_load_faces.Text = "Load Faces";
            this.btn_load_faces.UseVisualStyleBackColor = true;
            this.btn_load_faces.Click += new System.EventHandler(this.btn_load_faces_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(37, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // imageBoxFrameGrabber
            // 
            this.imageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageBoxFrameGrabber.Location = new System.Drawing.Point(13, 38);
            this.imageBoxFrameGrabber.Margin = new System.Windows.Forms.Padding(4);
            this.imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            this.imageBoxFrameGrabber.Size = new System.Drawing.Size(426, 295);
            this.imageBoxFrameGrabber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageBoxFrameGrabber.TabIndex = 4;
            this.imageBoxFrameGrabber.TabStop = false;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(563, 353);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(104, 35);
            this.btn_Stop.TabIndex = 21;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_picture_mode
            // 
            this.btn_picture_mode.Location = new System.Drawing.Point(753, 434);
            this.btn_picture_mode.Name = "btn_picture_mode";
            this.btn_picture_mode.Size = new System.Drawing.Size(104, 35);
            this.btn_picture_mode.TabIndex = 23;
            this.btn_picture_mode.Text = "Picture Mode";
            this.btn_picture_mode.UseVisualStyleBackColor = true;
            this.btn_picture_mode.Click += new System.EventHandler(this.btn_picture_mode_Click);
            // 
            // btn_video_mode
            // 
            this.btn_video_mode.Location = new System.Drawing.Point(873, 434);
            this.btn_video_mode.Name = "btn_video_mode";
            this.btn_video_mode.Size = new System.Drawing.Size(104, 35);
            this.btn_video_mode.TabIndex = 24;
            this.btn_video_mode.Text = "Video Mode";
            this.btn_video_mode.UseVisualStyleBackColor = true;
            this.btn_video_mode.Click += new System.EventHandler(this.btn_video_mode_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(820, 475);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(104, 35);
            this.btn_browse.TabIndex = 25;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 672);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.btn_video_mode);
            this.Controls.Add(this.btn_picture_mode);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_recognize);
            this.Controls.Add(this.btn_add_DB);
            this.Controls.Add(this.btn_detect);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imageBoxFrameGrabber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.Text = "Dafer\'s face detection and recognizer ";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_detect;
        private System.Windows.Forms.Button btn_add_DB;
        private System.Windows.Forms.Button btn_recognize;
        private System.Windows.Forms.Button btn_delete_face;
        private System.Windows.Forms.Button btn_update_name;
        private System.Windows.Forms.Button btn_scroll_back;
        private System.Windows.Forms.Button btn_scroll_fwd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_load_faces;
        private System.Windows.Forms.Button btn_refresh_camerlist;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCamIndex;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_continue;
        private System.Windows.Forms.Button btn_picture_mode;
        private System.Windows.Forms.Button btn_video_mode;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label lb_face_count;
        private System.Windows.Forms.Button btn_delete_all;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_face_names;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

