namespace InstrumentumColorPicker {

    partial class ColorPicker {
        
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.radioButtonHV = new System.Windows.Forms.RadioButton();
            this.labelSec = new System.Windows.Forms.Label();
            this.radioButtonHS = new System.Windows.Forms.RadioButton();
            this.colorPri = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelPri = new System.Windows.Forms.Label();
            this.colorSec = new System.Windows.Forms.PictureBox();
            this.colorHex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.colorPbA = new System.Windows.Forms.PictureBox();
            this.colorNudA = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.colorPbV = new System.Windows.Forms.PictureBox();
            this.colorNudV = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.colorPbS = new System.Windows.Forms.PictureBox();
            this.colorNudS = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.colorPbH = new System.Windows.Forms.PictureBox();
            this.colorNudH = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.colorPbB = new System.Windows.Forms.PictureBox();
            this.colorNudB = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.colorPbG = new System.Windows.Forms.PictureBox();
            this.colorNudG = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.colorPbR = new System.Windows.Forms.PictureBox();
            this.colorNudR = new System.Windows.Forms.NumericUpDown();
            this.colorPbWheel = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.colorSwapPb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorPri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbWheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSwapPb)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonHV
            // 
            this.radioButtonHV.AutoSize = true;
            this.radioButtonHV.Checked = true;
            this.radioButtonHV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonHV.Location = new System.Drawing.Point(145, 231);
            this.radioButtonHV.Name = "radioButtonHV";
            this.radioButtonHV.Size = new System.Drawing.Size(40, 17);
            this.radioButtonHV.TabIndex = 73;
            this.radioButtonHV.TabStop = true;
            this.radioButtonHV.Text = "HV";
            this.toolTip.SetToolTip(this.radioButtonHV, "Hue - Value");
            this.radioButtonHV.UseVisualStyleBackColor = true;
            this.radioButtonHV.CheckedChanged += new System.EventHandler(this.radioButtonHSxV_CheckedChanged);
            // 
            // labelSec
            // 
            this.labelSec.AutoSize = true;
            this.labelSec.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.labelSec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSec.Location = new System.Drawing.Point(148, 17);
            this.labelSec.Name = "labelSec";
            this.labelSec.Size = new System.Drawing.Size(32, 18);
            this.labelSec.TabIndex = 70;
            this.labelSec.Text = "Sec";
            // 
            // radioButtonHS
            // 
            this.radioButtonHS.AutoSize = true;
            this.radioButtonHS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonHS.Location = new System.Drawing.Point(99, 231);
            this.radioButtonHS.Name = "radioButtonHS";
            this.radioButtonHS.Size = new System.Drawing.Size(40, 17);
            this.radioButtonHS.TabIndex = 72;
            this.radioButtonHS.Text = "HS";
            this.toolTip.SetToolTip(this.radioButtonHS, "Hue - Saturation");
            this.radioButtonHS.UseVisualStyleBackColor = true;
            this.radioButtonHS.CheckedChanged += new System.EventHandler(this.radioButtonHSxV_CheckedChanged);
            // 
            // colorPri
            // 
            this.colorPri.Image = global::InstrumentumColorPicker.Properties.Resources.color_border;
            this.colorPri.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorPri.Location = new System.Drawing.Point(50, 3);
            this.colorPri.Name = "colorPri";
            this.colorPri.Size = new System.Drawing.Size(32, 32);
            this.colorPri.TabIndex = 67;
            this.colorPri.TabStop = false;
            this.colorPri.Click += new System.EventHandler(this.colorPri_Click);
            this.colorPri.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPri_Paint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(3, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 71;
            this.label11.Text = "Color wheel mode:";
            // 
            // labelPri
            // 
            this.labelPri.AutoSize = true;
            this.labelPri.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.labelPri.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPri.Location = new System.Drawing.Point(12, 17);
            this.labelPri.Name = "labelPri";
            this.labelPri.Size = new System.Drawing.Size(32, 18);
            this.labelPri.TabIndex = 69;
            this.labelPri.Text = "Pri";
            // 
            // colorSec
            // 
            this.colorSec.Image = global::InstrumentumColorPicker.Properties.Resources.color_border;
            this.colorSec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorSec.Location = new System.Drawing.Point(110, 3);
            this.colorSec.Name = "colorSec";
            this.colorSec.Size = new System.Drawing.Size(32, 32);
            this.colorSec.TabIndex = 68;
            this.colorSec.TabStop = false;
            this.colorSec.Click += new System.EventHandler(this.colorSec_Click);
            this.colorSec.Paint += new System.Windows.Forms.PaintEventHandler(this.colorSec_Paint);
            // 
            // colorHex
            // 
            this.colorHex.Location = new System.Drawing.Point(23, 437);
            this.colorHex.Name = "colorHex";
            this.colorHex.Size = new System.Drawing.Size(166, 20);
            this.colorHex.TabIndex = 52;
            this.colorHex.Text = "FFFFFF";
            this.colorHex.TextChanged += new System.EventHandler(this.color_HexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(3, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 18);
            this.label8.TabIndex = 66;
            this.label8.Text = "#";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(3, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 65;
            this.label5.Text = "A";
            // 
            // colorPbA
            // 
            this.colorPbA.Image = global::InstrumentumColorPicker.Properties.Resources.alpha;
            this.colorPbA.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorPbA.Location = new System.Drawing.Point(23, 411);
            this.colorPbA.Name = "colorPbA";
            this.colorPbA.Size = new System.Drawing.Size(112, 20);
            this.colorPbA.TabIndex = 63;
            this.colorPbA.TabStop = false;
            this.colorPbA.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPbA_Paint);
            this.colorPbA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseDown);
            this.colorPbA.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseMove);
            this.colorPbA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseUp);
            // 
            // colorNudA
            // 
            this.colorNudA.Location = new System.Drawing.Point(141, 411);
            this.colorNudA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorNudA.Name = "colorNudA";
            this.colorNudA.Size = new System.Drawing.Size(48, 20);
            this.colorNudA.TabIndex = 64;
            this.colorNudA.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorNudA.ValueChanged += new System.EventHandler(this.color_AlphaChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(3, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 18);
            this.label6.TabIndex = 62;
            this.label6.Text = "V";
            // 
            // colorPbV
            // 
            this.colorPbV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorPbV.Location = new System.Drawing.Point(23, 385);
            this.colorPbV.Name = "colorPbV";
            this.colorPbV.Size = new System.Drawing.Size(112, 20);
            this.colorPbV.TabIndex = 60;
            this.colorPbV.TabStop = false;
            this.colorPbV.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPbV_Paint);
            this.colorPbV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseDown);
            this.colorPbV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseMove);
            this.colorPbV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseUp);
            // 
            // colorNudV
            // 
            this.colorNudV.Location = new System.Drawing.Point(141, 385);
            this.colorNudV.Name = "colorNudV";
            this.colorNudV.Size = new System.Drawing.Size(48, 20);
            this.colorNudV.TabIndex = 61;
            this.colorNudV.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.colorNudV.ValueChanged += new System.EventHandler(this.color_HSVChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(3, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 18);
            this.label7.TabIndex = 59;
            this.label7.Text = "S";
            // 
            // colorPbS
            // 
            this.colorPbS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorPbS.Location = new System.Drawing.Point(23, 359);
            this.colorPbS.Name = "colorPbS";
            this.colorPbS.Size = new System.Drawing.Size(112, 20);
            this.colorPbS.TabIndex = 57;
            this.colorPbS.TabStop = false;
            this.colorPbS.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPbS_Paint);
            this.colorPbS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseDown);
            this.colorPbS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseMove);
            this.colorPbS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseUp);
            // 
            // colorNudS
            // 
            this.colorNudS.Location = new System.Drawing.Point(141, 359);
            this.colorNudS.Name = "colorNudS";
            this.colorNudS.Size = new System.Drawing.Size(48, 20);
            this.colorNudS.TabIndex = 58;
            this.colorNudS.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.colorNudS.ValueChanged += new System.EventHandler(this.color_HSVChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 18);
            this.label3.TabIndex = 56;
            this.label3.Text = "H";
            // 
            // colorPbH
            // 
            this.colorPbH.Image = global::InstrumentumColorPicker.Properties.Resources.hue;
            this.colorPbH.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorPbH.Location = new System.Drawing.Point(23, 333);
            this.colorPbH.Name = "colorPbH";
            this.colorPbH.Size = new System.Drawing.Size(112, 20);
            this.colorPbH.TabIndex = 54;
            this.colorPbH.TabStop = false;
            this.colorPbH.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPbH_Paint);
            this.colorPbH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseDown);
            this.colorPbH.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseMove);
            this.colorPbH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseUp);
            // 
            // colorNudH
            // 
            this.colorNudH.Location = new System.Drawing.Point(141, 333);
            this.colorNudH.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.colorNudH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.colorNudH.Name = "colorNudH";
            this.colorNudH.Size = new System.Drawing.Size(48, 20);
            this.colorNudH.TabIndex = 55;
            this.colorNudH.Value = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.colorNudH.ValueChanged += new System.EventHandler(this.colorNudH_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(3, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 18);
            this.label4.TabIndex = 53;
            this.label4.Text = "B";
            // 
            // colorPbB
            // 
            this.colorPbB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorPbB.Location = new System.Drawing.Point(23, 307);
            this.colorPbB.Name = "colorPbB";
            this.colorPbB.Size = new System.Drawing.Size(112, 20);
            this.colorPbB.TabIndex = 50;
            this.colorPbB.TabStop = false;
            this.colorPbB.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPbB_Paint);
            this.colorPbB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseDown);
            this.colorPbB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseMove);
            this.colorPbB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseUp);
            // 
            // colorNudB
            // 
            this.colorNudB.Location = new System.Drawing.Point(141, 307);
            this.colorNudB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorNudB.Name = "colorNudB";
            this.colorNudB.Size = new System.Drawing.Size(48, 20);
            this.colorNudB.TabIndex = 51;
            this.colorNudB.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorNudB.ValueChanged += new System.EventHandler(this.color_RGBChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 18);
            this.label2.TabIndex = 49;
            this.label2.Text = "G";
            // 
            // colorPbG
            // 
            this.colorPbG.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorPbG.Location = new System.Drawing.Point(23, 281);
            this.colorPbG.Name = "colorPbG";
            this.colorPbG.Size = new System.Drawing.Size(112, 20);
            this.colorPbG.TabIndex = 47;
            this.colorPbG.TabStop = false;
            this.colorPbG.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPbG_Paint);
            this.colorPbG.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseDown);
            this.colorPbG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseMove);
            this.colorPbG.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseUp);
            // 
            // colorNudG
            // 
            this.colorNudG.Location = new System.Drawing.Point(141, 281);
            this.colorNudG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorNudG.Name = "colorNudG";
            this.colorNudG.Size = new System.Drawing.Size(48, 20);
            this.colorNudG.TabIndex = 48;
            this.colorNudG.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorNudG.ValueChanged += new System.EventHandler(this.color_RGBChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 18);
            this.label1.TabIndex = 46;
            this.label1.Text = "R";
            // 
            // colorPbR
            // 
            this.colorPbR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorPbR.Location = new System.Drawing.Point(23, 255);
            this.colorPbR.Name = "colorPbR";
            this.colorPbR.Size = new System.Drawing.Size(112, 20);
            this.colorPbR.TabIndex = 44;
            this.colorPbR.TabStop = false;
            this.colorPbR.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPbR_Paint);
            this.colorPbR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseDown);
            this.colorPbR.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseMove);
            this.colorPbR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseUp);
            // 
            // colorNudR
            // 
            this.colorNudR.Location = new System.Drawing.Point(141, 255);
            this.colorNudR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorNudR.Name = "colorNudR";
            this.colorNudR.Size = new System.Drawing.Size(48, 20);
            this.colorNudR.TabIndex = 45;
            this.colorNudR.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.colorNudR.ValueChanged += new System.EventHandler(this.color_RGBChanged);
            // 
            // colorPbWheel
            // 
            this.colorPbWheel.Image = global::InstrumentumColorPicker.Properties.Resources.hue2;
            this.colorPbWheel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorPbWheel.Location = new System.Drawing.Point(3, 38);
            this.colorPbWheel.Name = "colorPbWheel";
            this.colorPbWheel.Size = new System.Drawing.Size(186, 186);
            this.colorPbWheel.TabIndex = 43;
            this.colorPbWheel.TabStop = false;
            this.colorPbWheel.Paint += new System.Windows.Forms.PaintEventHandler(this.colorPbWheel_Paint);
            this.colorPbWheel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseDown);
            this.colorPbWheel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseMove);
            this.colorPbWheel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.colorPb_MouseUp);
            // 
            // colorSwapPb
            // 
            this.colorSwapPb.Image = global::InstrumentumColorPicker.Properties.Resources.arrows_lr;
            this.colorSwapPb.Location = new System.Drawing.Point(88, 8);
            this.colorSwapPb.Name = "colorSwapPb";
            this.colorSwapPb.Size = new System.Drawing.Size(16, 22);
            this.colorSwapPb.TabIndex = 74;
            this.colorSwapPb.TabStop = false;
            this.colorSwapPb.Click += new System.EventHandler(this.colorSwapPb_Click);
            this.colorSwapPb.DoubleClick += new System.EventHandler(this.colorSwapPb_Click);
            // 
            // ColorPicker
            // 
            this.Controls.Add(this.colorSwapPb);
            this.Controls.Add(this.radioButtonHV);
            this.Controls.Add(this.labelSec);
            this.Controls.Add(this.radioButtonHS);
            this.Controls.Add(this.colorPri);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.labelPri);
            this.Controls.Add(this.colorSec);
            this.Controls.Add(this.colorHex);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.colorPbA);
            this.Controls.Add(this.colorNudA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.colorPbV);
            this.Controls.Add(this.colorNudV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.colorPbS);
            this.Controls.Add(this.colorNudS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.colorPbH);
            this.Controls.Add(this.colorNudH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.colorPbB);
            this.Controls.Add(this.colorNudB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorPbG);
            this.Controls.Add(this.colorNudG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorPbR);
            this.Controls.Add(this.colorNudR);
            this.Controls.Add(this.colorPbWheel);
            this.Name = "ColorPicker";
            this.Size = new System.Drawing.Size(192, 460);
            ((System.ComponentModel.ISupportInitialize)(this.colorPri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorNudR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPbWheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSwapPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonHV;
        private System.Windows.Forms.Label labelSec;
        private System.Windows.Forms.RadioButton radioButtonHS;
        private System.Windows.Forms.PictureBox colorPri;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelPri;
        private System.Windows.Forms.PictureBox colorSec;
        private System.Windows.Forms.TextBox colorHex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox colorPbA;
        private System.Windows.Forms.NumericUpDown colorNudA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox colorPbV;
        private System.Windows.Forms.NumericUpDown colorNudV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox colorPbS;
        private System.Windows.Forms.NumericUpDown colorNudS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox colorPbH;
        private System.Windows.Forms.NumericUpDown colorNudH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox colorPbB;
        private System.Windows.Forms.NumericUpDown colorNudB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox colorPbG;
        private System.Windows.Forms.NumericUpDown colorNudG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox colorPbR;
        private System.Windows.Forms.NumericUpDown colorNudR;
        private System.Windows.Forms.PictureBox colorPbWheel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox colorSwapPb;
    }
}
