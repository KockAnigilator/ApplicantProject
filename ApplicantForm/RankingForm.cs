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
            // Получаем данные из базы данных
            var ranking = _service.GetApplicantsRanking();

            // Привязываем данные к DataGridView
            dataGridView.DataSource = ranking;

            // Автоматически создаем столбцы на основе свойств объекта
            dataGridView.AutoGenerateColumns = true;
        }
    }
}
