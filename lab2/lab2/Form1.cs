using lab2;
using System;
using System.Linq;
using System.Windows.Forms;


namespace lab2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            /// <summary>
            /// Метод-конструтор класса формы
            /// </summary>
            
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(310, 164);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(126, 31);
            this.textBox3.TabIndex = 0;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress_1);
            this.textBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyUp_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(764, 361);
            this.Controls.Add(this.textBox3);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private string template = "";
        private int templatePartIndex = 0;
        bool force_next_stage = false;

        private void processTemplateInput(KeyPressEventArgs e)
        {
            /// <summary>
            /// Метод обработки нажатия клавиши для формирования шаблона
            /// </summary>
            
            if (textBox3.Text.Length == 0 && e.KeyChar != '[')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '[')
            {
                if (textBox3.Text.Length != 0) e.Handled = true;
                return;
            }

            if (e.KeyChar == ']')
            {
                if ((textBox3.Text.Length - 1) % Constants.TEMPLATE_PARTS_SYMBOLS.Length != 0) e.Handled = true;
                return;
            }
            if (textBox3.Text.Length != 0)
            {
                char[] allowed_symbols = (char[])Constants.TEMPLATE_PARTS_SYMBOLS.GetValue((textBox3.Text.Length - 1) % Constants.TEMPLATE_PARTS_SYMBOLS.Length);
                if (!allowed_symbols.Contains(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private int getWordSymbolTemplate(string template, int templatePartIndex)
        {
            /// <summary>
            /// Метод получения символа буквы
            /// </summary>
            int element = Constants.TEMPLATE_PARTS_SYMBOLS.Length * templatePartIndex;
            return template.ElementAt(element);
        }

        private int getActionTemplate(string template, int templatePartIndex)
        {
            /// <summary>
            /// Метод получения символа действия с буквой
            /// </summary>
            int element = Constants.TEMPLATE_PARTS_SYMBOLS.Length * templatePartIndex + 1;
            return template.ElementAt(element);
        }

        private int getAdditionalSymbolTemplate(string template, int templatePartIndex)
        {
            /// <summary>
            /// Метод получения добавочного символа в конце части шаблона
            /// </summary>
            int element = Constants.TEMPLATE_PARTS_SYMBOLS.Length * templatePartIndex + 3;
            return template.ElementAt(element);
        }

        private int getRepetitionFactorTemplate(string template, int templatePartIndex)
        {
            /// <summary>
            /// Метод получения символа повторения части шаблона
            /// </summary>
            int element = Constants.TEMPLATE_PARTS_SYMBOLS.Length * templatePartIndex + 2;
            return template.ElementAt(element);
        }

        private void incrimentPart()
        {
            templatePartIndex += 1;
        }

        private void transformWord(KeyPressEventArgs e)
        {
            /// <summary>
            /// Метод изменения символа в зависимости от шаблона
            /// </summary>
            if (getActionTemplate(template, templatePartIndex) == Constants.TO_LOWER) e.KeyChar = Char.ToLower(e.KeyChar);
            if (getActionTemplate(template, templatePartIndex) == Constants.TO_UPPER) e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void processFioInput(KeyPressEventArgs e)
        {
            /// <summary>
            /// обработки нажатия клавиши для формирования вывода ФИО
            /// </summary>
            if (e.KeyChar == Constants.NEXT_TEMPLATE_PART)
            {
                e.Handled = true;
                force_next_stage = true;
                return;
            }
            if (!Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                return;
            };
            transformWord(e);
        }

        private void textBox3_KeyUp_1(object sender, KeyEventArgs e)
        {
            /// <summary>
            /// Метод обработки поднятия клавиши 
            /// </summary>
            
            // обрабатываем темплейт
            if (template.Length == 0)
            {
                if (textBox3.Text.Length != 0)
                {
                    if (textBox3.Text.Last() == ']')
                    {
                        template = textBox3.Text;
                        template = template.Remove(0, 1);
                        template = template.Remove(template.Length - 1, 1);
                        textBox3.Text = null;
                    }
                }
                return;
            }
            // обрабатываем ввод фио
            if (force_next_stage || getRepetitionFactorTemplate(template, templatePartIndex) == '?')
            {
                if (getAdditionalSymbolTemplate(template, templatePartIndex) == Constants.ADD_DASH) textBox3.AppendText("-");
                if (getAdditionalSymbolTemplate(template, templatePartIndex) == Constants.ADD_SPACE) textBox3.AppendText(" ");
                if (getAdditionalSymbolTemplate(template, templatePartIndex) == Constants.ADD_POINT) textBox3.AppendText(".");
                templatePartIndex++;
                force_next_stage = false;
            }

            if (templatePartIndex >= template.Length / Constants.TEMPLATE_PARTS_SYMBOLS.Length)
            {
                templatePartIndex = 0;
                textBox3.SelectionStart = 0;
                textBox3.SelectionLength = textBox3.Text.Length;
                return;
            }
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            /// <summary>
            /// Метод-триггер нажатия кнопки
            /// </summary>

            //if (e.KeyChar == (char)Keys.Delete)
            //{
            //    textBox3.Text.Remove(textBox3.Text.Length);
            //}


            if (template.Length == 0)
            {
                processTemplateInput(e);
            }
            else
            {
                processFioInput(e);
            }

        }
    }
}
