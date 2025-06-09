using System;
using System.Drawing;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using POO_Buscarr.controller;

namespace POO_Buscarr.view
{
    partial class TelaCadastro
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
            this.components = new System.ComponentModel.Container();
            this.checkTermos = new System.Windows.Forms.Button();
            this.pbBotao = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_cadastrar = new System.Windows.Forms.Button();
            this.campoNome = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.campoEmail = new System.Windows.Forms.TextBox();
            this.campoCPF = new System.Windows.Forms.TextBox();
            this.campoSenha1 = new System.Windows.Forms.TextBox();
            this.campoSenha2 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBotao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkTermos
            // 
            this.checkTermos.Location = new System.Drawing.Point(1164, 776);
            this.checkTermos.Name = "checkTermos";
            this.checkTermos.Size = new System.Drawing.Size(30, 30);
            this.checkTermos.TabIndex = 12;
            this.checkTermos.UseVisualStyleBackColor = true;
            this.checkTermos.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbBotao
            // 
            this.pbBotao.BackColor = System.Drawing.Color.Transparent;
            this.pbBotao.Location = new System.Drawing.Point(100, 100);
            this.pbBotao.Name = "pbBotao";
            this.pbBotao.Size = new System.Drawing.Size(100, 50);
            this.pbBotao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBotao.TabIndex = 0;
            this.pbBotao.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(1095, 942);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 35);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cadastrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_cadastrar.FlatAppearance.BorderSize = 0;
            this.btn_cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar.ForeColor = System.Drawing.Color.Transparent;
            this.btn_cadastrar.Image = global::POO_Buscarr.Properties.Resources.btnCadastrar;
            this.btn_cadastrar.Location = new System.Drawing.Point(1060, 831);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.Size = new System.Drawing.Size(438, 89);
            this.btn_cadastrar.TabIndex = 24;
            this.btn_cadastrar.UseVisualStyleBackColor = false;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
            // 
            // campoNome
            // 
            this.campoNome.BackColor = System.Drawing.SystemColors.Window;
            this.campoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoNome.Location = new System.Drawing.Point(967, 232);
            this.campoNome.Name = "campoNome";
            this.campoNome.Size = new System.Drawing.Size(619, 44);
            this.campoNome.TabIndex = 25;
            this.campoNome.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // campoEmail
            // 
            this.campoEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoEmail.Location = new System.Drawing.Point(967, 347);
            this.campoEmail.Name = "campoEmail";
            this.campoEmail.Size = new System.Drawing.Size(619, 44);
            this.campoEmail.TabIndex = 26;
            this.campoEmail.TextChanged += new System.EventHandler(this.campoEmail_TextChanged);
            // 
            // campoCPF
            // 
            this.campoCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoCPF.Location = new System.Drawing.Point(967, 464);
            this.campoCPF.Name = "campoCPF";
            this.campoCPF.Size = new System.Drawing.Size(619, 44);
            this.campoCPF.TabIndex = 27;
            this.campoCPF.TextChanged += new System.EventHandler(this.campoCPF_TextChanged);
            // 
            // campoSenha1
            // 
            this.campoSenha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoSenha1.Location = new System.Drawing.Point(967, 577);
            this.campoSenha1.Name = "campoSenha1";
            this.campoSenha1.PasswordChar = '*';
            this.campoSenha1.Size = new System.Drawing.Size(619, 44);
            this.campoSenha1.TabIndex = 28;
            this.campoSenha1.TextChanged += new System.EventHandler(this.campoSenha1_TextChanged);
            // 
            // campoSenha2
            // 
            this.campoSenha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoSenha2.Location = new System.Drawing.Point(967, 692);
            this.campoSenha2.Name = "campoSenha2";
            this.campoSenha2.PasswordChar = '*';
            this.campoSenha2.Size = new System.Drawing.Size(611, 44);
            this.campoSenha2.TabIndex = 29;
            this.campoSenha2.TextChanged += new System.EventHandler(this.campoSenha2_TextChanged);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1389, 776);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 30;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TelaCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImage = global::POO_Buscarr.Properties.Resources.TelaCadastroAtualizada;
            this.ClientSize = new System.Drawing.Size(1653, 936);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.campoSenha2);
            this.Controls.Add(this.campoSenha1);
            this.Controls.Add(this.campoCPF);
            this.Controls.Add(this.campoEmail);
            this.Controls.Add(this.campoNome);
            this.Controls.Add(this.btn_cadastrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkTermos);
            this.Name = "TelaCadastro";
            this.Text = "TelaCadastro";
            ((System.ComponentModel.ISupportInitialize)(this.pbBotao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button checkTermos;
        private PictureBox pbBotao;
        private PictureBox pictureBox1;
        private Button btn_cadastrar;
        private TextBox campoNome;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox campoEmail;
        private TextBox campoCPF;
        private TextBox campoSenha1;
        private TextBox campoSenha2;
        private ContextMenuStrip contextMenuStrip2;
        private Button button1;
    }
}