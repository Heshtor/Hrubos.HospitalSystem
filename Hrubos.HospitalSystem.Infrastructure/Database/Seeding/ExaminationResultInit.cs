using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class ExaminationResultInit
    {
        public List<ExaminationResult> GenerateExaminationResults()
        {
            return new List<ExaminationResult>()
            {
                new ExaminationResult
                {
                    Id = 1,
                    Description = "vše v pořádku",
                    Values = "TK: 120/80, Puls: 72",
                    Attachment = null,
                    ExaminationId = 1
                },
                new ExaminationResult
                {
                    Id = 2,
                    Description = "lehká anémie",
                    Values = "Hemoglobin: 110 g/l, Hct: 33%",
                    Attachment = null,
                    ExaminationId = 2
                },
                new ExaminationResult
                {
                    Id = 3,
                    Description = "artritida kolene",
                    Values = "RTG: mírná artritida, rentgenový snímek v příloze",
                    Attachment = "cloub_knee_xray.jpg",
                    ExaminationId = 3
                }
            };
        }
    }
}
