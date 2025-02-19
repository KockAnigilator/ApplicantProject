using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionCommitteeBackend
{
    public class Applicant
    {
        public int Id { get; set; } // Уникальный идентификатор абитуриента
        public string FullName { get; set; } // ФИО
        public string Email { get; set; } // Электронная почта
        public string Phone { get; set; } // Телефон
        public int ExamScore { get; set; } // Баллы ЕГЭ
        public string Documents { get; set; } // Документы (путь к файлу или текст)
        public string Benefits { get; set; } // Льготы (опционально)
    }
}
