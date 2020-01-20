namespace OPCServer1.Forms
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DbStatusLabel = new System.Windows.Forms.Label();
            this.diagrams1 = new OPCServer1.Diagrams();
            this.history1 = new OPCServer1.History();
            this.controllerValues1 = new OPCServer1.ControllerValues();
            this.currentlyMeasurement1 = new OPCServer1.CurrentlyMeasurement();
            this.button8 = new System.Windows.Forms.Button();
            this.PlcStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Połączenie z Bazą Danych";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Połączenie z PLC";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(221, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "Aktualne Parametry";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(314, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 35);
            this.button4.TabIndex = 3;
            this.button4.Text = "Sterowanie Podrzędne";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(397, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 35);
            this.button5.TabIndex = 4;
            this.button5.Text = "Historia Pomiarów";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(22, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(884, 2);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(797, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "PROGRAM TO COMMUNICATION BETWEEN PC AND PLC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(234, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(426, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Authors: Daniel Michrowski and Dominik Nowak";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(490, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 35);
            this.button6.TabIndex = 8;
            this.button6.Text = "Diagramy";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(710, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(68, 35);
            this.button7.TabIndex = 13;
            this.button7.Text = "Strona Główna";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(784, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Baza danych:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(784, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Sterownik PLC:";
            // 
            // DbStatusLabel
            // 
            this.DbStatusLabel.AutoSize = true;
            this.DbStatusLabel.Location = new System.Drawing.Point(864, 13);
            this.DbStatusLabel.Name = "DbStatusLabel";
            this.DbStatusLabel.Size = new System.Drawing.Size(71, 13);
            this.DbStatusLabel.TabIndex = 16;
            this.DbStatusLabel.Text = "disconnected";
            this.DbStatusLabel.Click += new System.EventHandler(this.label6_Click);
            // 
            // diagrams1
            // 
            this.diagrams1.Location = new System.Drawing.Point(0, 58);
            this.diagrams1.Name = "diagrams1";
            this.diagrams1.Size = new System.Drawing.Size(935, 655);
            this.diagrams1.TabIndex = 12;
            this.diagrams1.Load += new System.EventHandler(this.diagrams1_Load);
            // 
            // history1
            // 
            this.history1.Location = new System.Drawing.Point(0, 53);
            this.history1.Name = "history1";
            this.history1.Size = new System.Drawing.Size(935, 660);
            this.history1.TabIndex = 11;
            // 
            // controllerValues1
            // 
            this.controllerValues1.Location = new System.Drawing.Point(0, 53);
            this.controllerValues1.Name = "controllerValues1";
            this.controllerValues1.Size = new System.Drawing.Size(935, 660);
            this.controllerValues1.TabIndex = 10;
            // 
            // currentlyMeasurement1
            // 
            this.currentlyMeasurement1.BackColor = System.Drawing.Color.White;
            this.currentlyMeasurement1.Location = new System.Drawing.Point(0, 53);
            this.currentlyMeasurement1.Name = "currentlyMeasurement1";
            this.currentlyMeasurement1.Size = new System.Drawing.Size(935, 660);
            this.currentlyMeasurement1.TabIndex = 9;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(560, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(76, 35);
            this.button8.TabIndex = 17;
            this.button8.Text = "Wizualizacja";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // PlcStatusLabel
            // 
            this.PlcStatusLabel.AutoSize = true;
            this.PlcStatusLabel.Location = new System.Drawing.Point(870, 34);
            this.PlcStatusLabel.Name = "PlcStatusLabel";
            this.PlcStatusLabel.Size = new System.Drawing.Size(71, 13);
            this.PlcStatusLabel.TabIndex = 19;
            this.PlcStatusLabel.Text = "disconnected";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 711);
            this.Controls.Add(this.PlcStatusLabel);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.DbStatusLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.diagrams1);
            this.Controls.Add(this.history1);
            this.Controls.Add(this.controllerValues1);
            this.Controls.Add(this.currentlyMeasurement1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private CurrentlyMeasurement currentlyMeasurement1;
        private ControllerValues controllerValues1;
        private History history1;
        private Diagrams diagrams1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label DbStatusLabel;
        private System.Windows.Forms.Button button8;
        public System.Windows.Forms.Label PlcStatusLabel;
    }
}