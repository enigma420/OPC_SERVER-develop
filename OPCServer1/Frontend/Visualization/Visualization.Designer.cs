namespace OPCServer1.Frontend.Visualization
{
    partial class Visualization
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
            this.weightIndicator1 = new OPCServer1.Frontend.Visualization.Components.WeightIndicator();
            this.SuspendLayout();
            // 
            // weightIndicator1
            // 
            this.weightIndicator1.backgroundcolor = System.Drawing.Color.White;
            this.weightIndicator1.circlecolor = System.Drawing.Color.Black;
            this.weightIndicator1.controlfont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.weightIndicator1.Location = new System.Drawing.Point(98, 90);
            this.weightIndicator1.Name = "weightIndicator1";
            this.weightIndicator1.Size = new System.Drawing.Size(250, 250);
            this.weightIndicator1.TabIndex = 0;
            this.weightIndicator1.tipcolor = System.Drawing.Color.Red;
            this.weightIndicator1.tipwidth = 2F;
            this.weightIndicator1.valueactual = 0F;
            this.weightIndicator1.valuemax = 100F;
            this.weightIndicator1.valuemin = 0F;
            // 
            // Visualization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 709);
            this.Controls.Add(this.weightIndicator1);
            this.Name = "Visualization";
            this.Load += new System.EventHandler(this.Visualization_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.WeightIndicator weightIndicator1;
    }
}