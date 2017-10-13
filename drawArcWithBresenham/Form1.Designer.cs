namespace drawArcWithBresenham {
    partial class pixelForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.startInfolbl = new System.Windows.Forms.Label();
            this.startPoilbl = new System.Windows.Forms.Label();
            this.endInfolbl = new System.Windows.Forms.Label();
            this.endPoilbl = new System.Windows.Forms.Label();
            this.inTimelbl = new System.Windows.Forms.Label();
            this.intimePoilbl = new System.Windows.Forms.Label();
            this.radInfolbl = new System.Windows.Forms.Label();
            this.radiusTBox = new System.Windows.Forms.TextBox();
            this.drawLineBtn = new System.Windows.Forms.Button();
            this.drawArcBtn = new System.Windows.Forms.Button();
            this.drawCircleBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startInfolbl
            // 
            this.startInfolbl.AutoSize = true;
            this.startInfolbl.ForeColor = System.Drawing.Color.Red;
            this.startInfolbl.Location = new System.Drawing.Point(13, 3);
            this.startInfolbl.Name = "startInfolbl";
            this.startInfolbl.Size = new System.Drawing.Size(35, 12);
            this.startInfolbl.TabIndex = 0;
            this.startInfolbl.Text = "起点:";
            // 
            // startPoilbl
            // 
            this.startPoilbl.AutoSize = true;
            this.startPoilbl.Location = new System.Drawing.Point(55, 3);
            this.startPoilbl.Name = "startPoilbl";
            this.startPoilbl.Size = new System.Drawing.Size(65, 12);
            this.startPoilbl.TabIndex = 1;
            this.startPoilbl.Text = "{   ,    }";
            // 
            // endInfolbl
            // 
            this.endInfolbl.AutoSize = true;
            this.endInfolbl.ForeColor = System.Drawing.Color.Red;
            this.endInfolbl.Location = new System.Drawing.Point(140, 3);
            this.endInfolbl.Name = "endInfolbl";
            this.endInfolbl.Size = new System.Drawing.Size(35, 12);
            this.endInfolbl.TabIndex = 2;
            this.endInfolbl.Text = "终点:";
            // 
            // endPoilbl
            // 
            this.endPoilbl.AutoSize = true;
            this.endPoilbl.Location = new System.Drawing.Point(182, 3);
            this.endPoilbl.Name = "endPoilbl";
            this.endPoilbl.Size = new System.Drawing.Size(59, 12);
            this.endPoilbl.TabIndex = 3;
            this.endPoilbl.Text = "{   ,   }";
            // 
            // inTimelbl
            // 
            this.inTimelbl.AutoSize = true;
            this.inTimelbl.Location = new System.Drawing.Point(284, 2);
            this.inTimelbl.Name = "inTimelbl";
            this.inTimelbl.Size = new System.Drawing.Size(47, 12);
            this.inTimelbl.TabIndex = 4;
            this.inTimelbl.Text = "实时点:";
            // 
            // intimePoilbl
            // 
            this.intimePoilbl.AutoSize = true;
            this.intimePoilbl.Location = new System.Drawing.Point(347, 2);
            this.intimePoilbl.Name = "intimePoilbl";
            this.intimePoilbl.Size = new System.Drawing.Size(59, 12);
            this.intimePoilbl.TabIndex = 5;
            this.intimePoilbl.Text = "{   ,   }";
            // 
            // radInfolbl
            // 
            this.radInfolbl.AutoSize = true;
            this.radInfolbl.Location = new System.Drawing.Point(593, 3);
            this.radInfolbl.Name = "radInfolbl";
            this.radInfolbl.Size = new System.Drawing.Size(35, 12);
            this.radInfolbl.TabIndex = 6;
            this.radInfolbl.Text = "半径:";
            // 
            // radiusTBox
            // 
            this.radiusTBox.Location = new System.Drawing.Point(634, 0);
            this.radiusTBox.Name = "radiusTBox";
            this.radiusTBox.Size = new System.Drawing.Size(60, 21);
            this.radiusTBox.TabIndex = 7;
            this.radiusTBox.Text = "10";
            // 
            // drawLineBtn
            // 
            this.drawLineBtn.Location = new System.Drawing.Point(12, 562);
            this.drawLineBtn.Name = "drawLineBtn";
            this.drawLineBtn.Size = new System.Drawing.Size(75, 23);
            this.drawLineBtn.TabIndex = 8;
            this.drawLineBtn.Text = "画直线";
            this.drawLineBtn.UseVisualStyleBackColor = true;
            this.drawLineBtn.Click += new System.EventHandler(this.drawLineBtn_Click);
            // 
            // drawArcBtn
            // 
            this.drawArcBtn.Location = new System.Drawing.Point(93, 562);
            this.drawArcBtn.Name = "drawArcBtn";
            this.drawArcBtn.Size = new System.Drawing.Size(75, 23);
            this.drawArcBtn.TabIndex = 9;
            this.drawArcBtn.Text = "画圆弧";
            this.drawArcBtn.UseVisualStyleBackColor = true;
            this.drawArcBtn.Click += new System.EventHandler(this.drawArcBtn_Click);
            // 
            // drawCircleBtn
            // 
            this.drawCircleBtn.Location = new System.Drawing.Point(184, 562);
            this.drawCircleBtn.Name = "drawCircleBtn";
            this.drawCircleBtn.Size = new System.Drawing.Size(75, 23);
            this.drawCircleBtn.TabIndex = 10;
            this.drawCircleBtn.Text = "画圆";
            this.drawCircleBtn.UseVisualStyleBackColor = true;
            this.drawCircleBtn.Click += new System.EventHandler(this.drawCircleBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(276, 562);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 11;
            this.clearBtn.Text = "清除";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // pixelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 588);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.drawCircleBtn);
            this.Controls.Add(this.drawArcBtn);
            this.Controls.Add(this.drawLineBtn);
            this.Controls.Add(this.radiusTBox);
            this.Controls.Add(this.radInfolbl);
            this.Controls.Add(this.intimePoilbl);
            this.Controls.Add(this.inTimelbl);
            this.Controls.Add(this.endPoilbl);
            this.Controls.Add(this.endInfolbl);
            this.Controls.Add(this.startPoilbl);
            this.Controls.Add(this.startInfolbl);
            this.Name = "pixelForm";
            this.Text = "Bresenham画弧";
            this.Load += new System.EventHandler(this.pixelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label startInfolbl;
        private System.Windows.Forms.Label startPoilbl;
        private System.Windows.Forms.Label endInfolbl;
        private System.Windows.Forms.Label endPoilbl;
        private System.Windows.Forms.Label inTimelbl;
        private System.Windows.Forms.Label intimePoilbl;
        private System.Windows.Forms.Label radInfolbl;
        private System.Windows.Forms.TextBox radiusTBox;
        private System.Windows.Forms.Button drawLineBtn;
        private System.Windows.Forms.Button drawArcBtn;
        private System.Windows.Forms.Button drawCircleBtn;
        private System.Windows.Forms.Button clearBtn;
    }
}

