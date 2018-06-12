using Grafy_mag.Models;

namespace Grafy_mag
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_generate = new System.Windows.Forms.Button();
            this.wpfHost = new System.Windows.Forms.Integration.ElementHost();
            this.btn_reload = new System.Windows.Forms.Button();
            this.txb_prob = new System.Windows.Forms.TextBox();
            this.lbl_prob = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_next_weights = new System.Windows.Forms.Button();
            this.lbl_weight = new System.Windows.Forms.Label();
            this.lbl_weight_layer = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_mut = new System.Windows.Forms.Label();
            this.txb_mut_prob = new System.Windows.Forms.TextBox();
            this.lbl_pop = new System.Windows.Forms.Label();
            this.txb_pop_size = new System.Windows.Forms.TextBox();
            this.lbl_iters = new System.Windows.Forms.Label();
            this.txb_iter_count = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.lbl_f1 = new System.Windows.Forms.Label();
            this.lbl_best1 = new System.Windows.Forms.Label();
            this.lbl_best1_cycle = new System.Windows.Forms.Label();
            this.lbl_best2_cycle = new System.Windows.Forms.Label();
            this.lbl_best2 = new System.Windows.Forms.Label();
            this.lbl_f2 = new System.Windows.Forms.Label();
            this.lbl_best3_cycle = new System.Windows.Forms.Label();
            this.lbl_best3 = new System.Windows.Forms.Label();
            this.lbl_f3 = new System.Windows.Forms.Label();
            this.lbl_best1_cost = new System.Windows.Forms.Label();
            this.lbl_best2_cost = new System.Windows.Forms.Label();
            this.lbl_best3_cost = new System.Windows.Forms.Label();
            this.lbl_pareto = new System.Windows.Forms.Label();
            this.listView4 = new System.Windows.Forms.ListView();
            this.lbl_iter_txt = new System.Windows.Forms.Label();
            this.lbl_iter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_generate
            // 
            this.btn_generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_generate.Location = new System.Drawing.Point(952, 0);
            this.btn_generate.Margin = new System.Windows.Forms.Padding(4);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(133, 28);
            this.btn_generate.TabIndex = 0;
            this.btn_generate.Text = "Generate";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.Btn_generate_Click);
            // 
            // wpfHost
            // 
            this.wpfHost.BackColor = System.Drawing.Color.White;
            this.wpfHost.Location = new System.Drawing.Point(0, 0);
            this.wpfHost.Margin = new System.Windows.Forms.Padding(4);
            this.wpfHost.Name = "wpfHost";
            this.wpfHost.Size = new System.Drawing.Size(940, 460);
            this.wpfHost.TabIndex = 1;
            this.wpfHost.Text = "elementHost1";
            this.wpfHost.Child = null;
            // 
            // btn_reload
            // 
            this.btn_reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reload.Location = new System.Drawing.Point(952, 36);
            this.btn_reload.Margin = new System.Windows.Forms.Padding(4);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(133, 28);
            this.btn_reload.TabIndex = 2;
            this.btn_reload.Text = "Rearrange";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.Btn_reload_Click);
            // 
            // txb_prob
            // 
            this.txb_prob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_prob.Location = new System.Drawing.Point(952, 87);
            this.txb_prob.Margin = new System.Windows.Forms.Padding(4);
            this.txb_prob.Name = "txb_prob";
            this.txb_prob.Size = new System.Drawing.Size(132, 22);
            this.txb_prob.TabIndex = 3;
            this.txb_prob.Text = "0.95";
            // 
            // lbl_prob
            // 
            this.lbl_prob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_prob.AutoSize = true;
            this.lbl_prob.Location = new System.Drawing.Point(952, 68);
            this.lbl_prob.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_prob.Name = "lbl_prob";
            this.lbl_prob.Size = new System.Drawing.Size(110, 17);
            this.lbl_prob.TabIndex = 4;
            this.lbl_prob.Text = "Edge probability";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(948, 628);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_next_weights
            // 
            this.btn_next_weights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_next_weights.Location = new System.Drawing.Point(951, 119);
            this.btn_next_weights.Margin = new System.Windows.Forms.Padding(4);
            this.btn_next_weights.Name = "btn_next_weights";
            this.btn_next_weights.Size = new System.Drawing.Size(133, 28);
            this.btn_next_weights.TabIndex = 6;
            this.btn_next_weights.Text = "Next weights";
            this.btn_next_weights.UseVisualStyleBackColor = true;
            this.btn_next_weights.Click += new System.EventHandler(this.btn_next_weights_Click);
            // 
            // lbl_weight
            // 
            this.lbl_weight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_weight.AutoSize = true;
            this.lbl_weight.Location = new System.Drawing.Point(951, 151);
            this.lbl_weight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_weight.Name = "lbl_weight";
            this.lbl_weight.Size = new System.Drawing.Size(91, 17);
            this.lbl_weight.TabIndex = 7;
            this.lbl_weight.Text = "Weight layer:";
            // 
            // lbl_weight_layer
            // 
            this.lbl_weight_layer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_weight_layer.AutoSize = true;
            this.lbl_weight_layer.Location = new System.Drawing.Point(1043, 151);
            this.lbl_weight_layer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_weight_layer.Name = "lbl_weight_layer";
            this.lbl_weight_layer.Size = new System.Drawing.Size(16, 17);
            this.lbl_weight_layer.TabIndex = 8;
            this.lbl_weight_layer.Text = "1";
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.Location = new System.Drawing.Point(952, 364);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(133, 28);
            this.btn_start.TabIndex = 9;
            this.btn_start.Text = "Start evolution";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lbl_mut
            // 
            this.lbl_mut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_mut.AutoSize = true;
            this.lbl_mut.Location = new System.Drawing.Point(948, 313);
            this.lbl_mut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_mut.Name = "lbl_mut";
            this.lbl_mut.Size = new System.Drawing.Size(131, 17);
            this.lbl_mut.TabIndex = 10;
            this.lbl_mut.Text = "Mutation probability";
            // 
            // txb_mut_prob
            // 
            this.txb_mut_prob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_mut_prob.Location = new System.Drawing.Point(952, 332);
            this.txb_mut_prob.Margin = new System.Windows.Forms.Padding(4);
            this.txb_mut_prob.Name = "txb_mut_prob";
            this.txb_mut_prob.Size = new System.Drawing.Size(132, 22);
            this.txb_mut_prob.TabIndex = 11;
            this.txb_mut_prob.Text = "0.05";
            // 
            // lbl_pop
            // 
            this.lbl_pop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_pop.AutoSize = true;
            this.lbl_pop.Location = new System.Drawing.Point(952, 265);
            this.lbl_pop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_pop.Name = "lbl_pop";
            this.lbl_pop.Size = new System.Drawing.Size(104, 17);
            this.lbl_pop.TabIndex = 12;
            this.lbl_pop.Text = "Population size";
            // 
            // txb_pop_size
            // 
            this.txb_pop_size.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_pop_size.Location = new System.Drawing.Point(952, 284);
            this.txb_pop_size.Margin = new System.Windows.Forms.Padding(4);
            this.txb_pop_size.Name = "txb_pop_size";
            this.txb_pop_size.Size = new System.Drawing.Size(132, 22);
            this.txb_pop_size.TabIndex = 13;
            this.txb_pop_size.Text = "121";
            // 
            // lbl_iters
            // 
            this.lbl_iters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_iters.AutoSize = true;
            this.lbl_iters.Location = new System.Drawing.Point(948, 217);
            this.lbl_iters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_iters.Name = "lbl_iters";
            this.lbl_iters.Size = new System.Drawing.Size(66, 17);
            this.lbl_iters.TabIndex = 14;
            this.lbl_iters.Text = "Iterations";
            // 
            // txb_iter_count
            // 
            this.txb_iter_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_iter_count.Location = new System.Drawing.Point(952, 236);
            this.txb_iter_count.Margin = new System.Windows.Forms.Padding(4);
            this.txb_iter_count.Name = "txb_iter_count";
            this.txb_iter_count.Size = new System.Drawing.Size(132, 22);
            this.txb_iter_count.TabIndex = 15;
            this.txb_iter_count.Text = "100";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(0, 468);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(156, 159);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Location = new System.Drawing.Point(380, 468);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(157, 159);
            this.listView2.TabIndex = 17;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView3
            // 
            this.listView3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listView3.Location = new System.Drawing.Point(773, 468);
            this.listView3.Margin = new System.Windows.Forms.Padding(4);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(165, 159);
            this.listView3.TabIndex = 18;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // lbl_f1
            // 
            this.lbl_f1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_f1.AutoSize = true;
            this.lbl_f1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_f1.Location = new System.Drawing.Point(165, 468);
            this.lbl_f1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_f1.Name = "lbl_f1";
            this.lbl_f1.Size = new System.Drawing.Size(113, 25);
            this.lbl_f1.TabIndex = 19;
            this.lbl_f1.Text = "Function 1";
            // 
            // lbl_best1
            // 
            this.lbl_best1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_best1.AutoSize = true;
            this.lbl_best1.Location = new System.Drawing.Point(165, 510);
            this.lbl_best1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_best1.Name = "lbl_best1";
            this.lbl_best1.Size = new System.Drawing.Size(76, 17);
            this.lbl_best1.TabIndex = 20;
            this.lbl_best1.Text = "Best cycle:";
            // 
            // lbl_best1_cycle
            // 
            this.lbl_best1_cycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_best1_cycle.AutoSize = true;
            this.lbl_best1_cycle.Location = new System.Drawing.Point(165, 526);
            this.lbl_best1_cycle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_best1_cycle.Name = "lbl_best1_cycle";
            this.lbl_best1_cycle.Size = new System.Drawing.Size(40, 17);
            this.lbl_best1_cycle.TabIndex = 21;
            this.lbl_best1_cycle.Text = "none";
            // 
            // lbl_best2_cycle
            // 
            this.lbl_best2_cycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_best2_cycle.AutoSize = true;
            this.lbl_best2_cycle.Location = new System.Drawing.Point(547, 526);
            this.lbl_best2_cycle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_best2_cycle.Name = "lbl_best2_cycle";
            this.lbl_best2_cycle.Size = new System.Drawing.Size(40, 17);
            this.lbl_best2_cycle.TabIndex = 24;
            this.lbl_best2_cycle.Text = "none";
            // 
            // lbl_best2
            // 
            this.lbl_best2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_best2.AutoSize = true;
            this.lbl_best2.Location = new System.Drawing.Point(547, 510);
            this.lbl_best2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_best2.Name = "lbl_best2";
            this.lbl_best2.Size = new System.Drawing.Size(76, 17);
            this.lbl_best2.TabIndex = 23;
            this.lbl_best2.Text = "Best cycle:";
            // 
            // lbl_f2
            // 
            this.lbl_f2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_f2.AutoSize = true;
            this.lbl_f2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_f2.Location = new System.Drawing.Point(547, 468);
            this.lbl_f2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_f2.Name = "lbl_f2";
            this.lbl_f2.Size = new System.Drawing.Size(113, 25);
            this.lbl_f2.TabIndex = 22;
            this.lbl_f2.Text = "Function 2";
            // 
            // lbl_best3_cycle
            // 
            this.lbl_best3_cycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_best3_cycle.AutoSize = true;
            this.lbl_best3_cycle.Location = new System.Drawing.Point(945, 526);
            this.lbl_best3_cycle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_best3_cycle.Name = "lbl_best3_cycle";
            this.lbl_best3_cycle.Size = new System.Drawing.Size(40, 17);
            this.lbl_best3_cycle.TabIndex = 27;
            this.lbl_best3_cycle.Text = "none";
            // 
            // lbl_best3
            // 
            this.lbl_best3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_best3.AutoSize = true;
            this.lbl_best3.Location = new System.Drawing.Point(945, 510);
            this.lbl_best3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_best3.Name = "lbl_best3";
            this.lbl_best3.Size = new System.Drawing.Size(76, 17);
            this.lbl_best3.TabIndex = 26;
            this.lbl_best3.Text = "Best cycle:";
            // 
            // lbl_f3
            // 
            this.lbl_f3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_f3.AutoSize = true;
            this.lbl_f3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_f3.Location = new System.Drawing.Point(945, 468);
            this.lbl_f3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_f3.Name = "lbl_f3";
            this.lbl_f3.Size = new System.Drawing.Size(113, 25);
            this.lbl_f3.TabIndex = 25;
            this.lbl_f3.Text = "Function 3";
            // 
            // lbl_best1_cost
            // 
            this.lbl_best1_cost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_best1_cost.AutoSize = true;
            this.lbl_best1_cost.Location = new System.Drawing.Point(252, 510);
            this.lbl_best1_cost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_best1_cost.Name = "lbl_best1_cost";
            this.lbl_best1_cost.Size = new System.Drawing.Size(16, 17);
            this.lbl_best1_cost.TabIndex = 28;
            this.lbl_best1_cost.Text = "0";
            // 
            // lbl_best2_cost
            // 
            this.lbl_best2_cost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_best2_cost.AutoSize = true;
            this.lbl_best2_cost.Location = new System.Drawing.Point(633, 510);
            this.lbl_best2_cost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_best2_cost.Name = "lbl_best2_cost";
            this.lbl_best2_cost.Size = new System.Drawing.Size(16, 17);
            this.lbl_best2_cost.TabIndex = 29;
            this.lbl_best2_cost.Text = "0";
            // 
            // lbl_best3_cost
            // 
            this.lbl_best3_cost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_best3_cost.AutoSize = true;
            this.lbl_best3_cost.Location = new System.Drawing.Point(1032, 510);
            this.lbl_best3_cost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_best3_cost.Name = "lbl_best3_cost";
            this.lbl_best3_cost.Size = new System.Drawing.Size(16, 17);
            this.lbl_best3_cost.TabIndex = 30;
            this.lbl_best3_cost.Text = "0";
            // 
            // lbl_pareto
            // 
            this.lbl_pareto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_pareto.AutoSize = true;
            this.lbl_pareto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pareto.Location = new System.Drawing.Point(397, 631);
            this.lbl_pareto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_pareto.Name = "lbl_pareto";
            this.lbl_pareto.Size = new System.Drawing.Size(75, 25);
            this.lbl_pareto.TabIndex = 31;
            this.lbl_pareto.Text = "Pareto";
            // 
            // listView4
            // 
            this.listView4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listView4.LabelWrap = false;
            this.listView4.Location = new System.Drawing.Point(0, 660);
            this.listView4.Margin = new System.Windows.Forms.Padding(4);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(939, 159);
            this.listView4.TabIndex = 32;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.List;
            this.listView4.SelectedIndexChanged += new System.EventHandler(this.listView4_SelectedIndexChanged);
            // 
            // lbl_iter_txt
            // 
            this.lbl_iter_txt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_iter_txt.AutoSize = true;
            this.lbl_iter_txt.Location = new System.Drawing.Point(952, 396);
            this.lbl_iter_txt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_iter_txt.Name = "lbl_iter_txt";
            this.lbl_iter_txt.Size = new System.Drawing.Size(59, 17);
            this.lbl_iter_txt.TabIndex = 34;
            this.lbl_iter_txt.Text = "Iteration";
            // 
            // lbl_iter
            // 
            this.lbl_iter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_iter.AutoSize = true;
            this.lbl_iter.Location = new System.Drawing.Point(1027, 396);
            this.lbl_iter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_iter.Name = "lbl_iter";
            this.lbl_iter.Size = new System.Drawing.Size(16, 17);
            this.lbl_iter.TabIndex = 35;
            this.lbl_iter.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 826);
            this.Controls.Add(this.lbl_iter);
            this.Controls.Add(this.lbl_iter_txt);
            this.Controls.Add(this.listView4);
            this.Controls.Add(this.lbl_pareto);
            this.Controls.Add(this.lbl_best3_cost);
            this.Controls.Add(this.lbl_best2_cost);
            this.Controls.Add(this.lbl_best1_cost);
            this.Controls.Add(this.lbl_best3_cycle);
            this.Controls.Add(this.lbl_best3);
            this.Controls.Add(this.lbl_f3);
            this.Controls.Add(this.lbl_best2_cycle);
            this.Controls.Add(this.lbl_best2);
            this.Controls.Add(this.lbl_f2);
            this.Controls.Add(this.lbl_best1_cycle);
            this.Controls.Add(this.lbl_best1);
            this.Controls.Add(this.lbl_f1);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txb_iter_count);
            this.Controls.Add(this.lbl_iters);
            this.Controls.Add(this.txb_pop_size);
            this.Controls.Add(this.lbl_pop);
            this.Controls.Add(this.txb_mut_prob);
            this.Controls.Add(this.lbl_mut);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.lbl_weight_layer);
            this.Controls.Add(this.lbl_weight);
            this.Controls.Add(this.btn_next_weights);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_prob);
            this.Controls.Add(this.txb_prob);
            this.Controls.Add(this.btn_reload);
            this.Controls.Add(this.wpfHost);
            this.Controls.Add(this.btn_generate);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.Integration.ElementHost wpfHost;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.TextBox txb_prob;
        private System.Windows.Forms.Label lbl_prob;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_next_weights;
        private System.Windows.Forms.Label lbl_weight;
        private System.Windows.Forms.Label lbl_weight_layer;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lbl_mut;
        private System.Windows.Forms.TextBox txb_mut_prob;
        private System.Windows.Forms.Label lbl_pop;
        private System.Windows.Forms.TextBox txb_pop_size;
        private System.Windows.Forms.Label lbl_iters;
        private System.Windows.Forms.TextBox txb_iter_count;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label lbl_f1;
        private System.Windows.Forms.Label lbl_best1;
        private System.Windows.Forms.Label lbl_best1_cycle;
        private System.Windows.Forms.Label lbl_best2_cycle;
        private System.Windows.Forms.Label lbl_best2;
        private System.Windows.Forms.Label lbl_f2;
        private System.Windows.Forms.Label lbl_best3_cycle;
        private System.Windows.Forms.Label lbl_best3;
        private System.Windows.Forms.Label lbl_f3;
        private System.Windows.Forms.Label lbl_best1_cost;
        private System.Windows.Forms.Label lbl_best2_cost;
        private System.Windows.Forms.Label lbl_best3_cost;
        private System.Windows.Forms.Label lbl_pareto;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.Label lbl_iter_txt;
        private System.Windows.Forms.Label lbl_iter;
    }
}

