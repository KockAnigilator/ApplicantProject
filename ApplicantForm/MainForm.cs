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
    public partial class MainForm : Form
    {
        private AdmissionCommitteeService _service;

        public MainForm()
        {
            InitializeComponent();
            _service = new AdmissionCommitteeService();
        }

        private void btnAddApplicant_Click(object sender, EventArgs e)
        {
            var addForm = new AddApplicantForm(_service);
            addForm.ShowDialog();
        }

        private void btnShowRanking_Click(object sender, EventArgs e)
        {
            var rankingForm = new RankingForm(_service);
            rankingForm.ShowDialog();
        }
    }
}
