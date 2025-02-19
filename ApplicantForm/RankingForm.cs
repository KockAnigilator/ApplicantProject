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
    public partial class RankingForm : Form
    {
        private AdmissionCommitteeService _service;

        public RankingForm(AdmissionCommitteeService service)
        {
            InitializeComponent();
            _service = service;
            LoadRanking();
        }

        private void LoadRanking()
        {
            var ranking = _service.GetApplicantsRanking();
            dataGridView.DataSource = ranking;
        }
    }
}
