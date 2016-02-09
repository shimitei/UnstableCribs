using System;

namespace COIME
{
    partial class InputForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private SuggestCollection suggestCollection = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                suggestCollection.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.autocompleteMenu = new AutocompleteMenuNS.AutocompleteMenu();
            this.textBox = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // autocompleteMenu
            // 
            this.autocompleteMenu.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenu.Colors")));
            this.autocompleteMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocompleteMenu.ImageList = null;
            this.autocompleteMenu.Items = new string[0];
            this.autocompleteMenu.MinFragmentLength = 1;
            this.autocompleteMenu.SearchPattern = "[\\w]";
            this.autocompleteMenu.TargetControlWrapper = null;
            // 
            // textBox
            // 
            this.autocompleteMenu.SetAutocompleteMenu(this.textBox, null);
            this.textBox.Location = new System.Drawing.Point(1, 2);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(405, 25);
            this.textBox.TabIndex = 0;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(1, 46);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(405, 26);
            this.comboBox.TabIndex = 1;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 75);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "InputForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ComboBox comboBox;
    }
}

