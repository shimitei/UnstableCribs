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
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(254, 25);
            this.textBox.TabIndex = 0;
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Controls.Add(this.textBox);
            this.Name = "InputForm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu;
        private System.Windows.Forms.TextBox textBox;
    }
}

