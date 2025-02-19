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
                Documents = txtDocuments.Text,
                Benefits = txtBenefits.Text
            };

            _service.AddApplicant(applicant);
            MessageBox.Show("Абитуриент добавлен!");
            this.Close();
        }
    }
}
