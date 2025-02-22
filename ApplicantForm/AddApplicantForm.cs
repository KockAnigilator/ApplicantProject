using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdmissionCommitteeBackend;

namespace ApplicantForm
{
    /// <summary>
    /// Тут нужно добавить на форму элементы текстбоксы кнопку ну и там разбирешься по ходу дела и получает основная задача
    /// сейчас - создать бд для заполнения студентов регистрации и входа, нужно будет реализовать схему для бд + интерфейс полностью
    /// бэкенд уже готов главное чтобы нормально работал с бд которую я вскоре создам ну и впринципе все на этом можно я думаю реализовать
    /// все это дело до конца недели, если такое получится
    /// </summary>
    public partial class AddApplicantForm : Form
    {
        private AdmissionCommitteeService _service;

        public AddApplicantForm(AdmissionCommitteeService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var applicant = new Applicant
            {
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                ExamScore = int.Parse(txtExamScore.Text),
                Benefits = txtBenefits.Text
            };

            _service.AddApplicant(applicant);
            MessageBox.Show("Абитуриент добавлен!");
            this.Close();
        }
    }
}
