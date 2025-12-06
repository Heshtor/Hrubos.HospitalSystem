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
                    Description = "Vše v pořádku",
                    Values = "TK: 120/80, Puls: 72",
                    AttachmentSrc = null,
                    ExaminationId = 1
                },
                new ExaminationResult
                {
                    Id = 2,
                    Description = "Lehká anémie",
                    Values = "Hemoglobin: 110 g/l, Hct: 33%",
                    AttachmentSrc = "\\attachments\\examinationResults\\erecept.png",
                    ExaminationId = 2
                },
                new ExaminationResult
                {
                    Id = 3,
                    Description = "Artritida kolene",
                    Values = "RTG: mírná artritida, rentgenový snímek v příloze",
                    AttachmentSrc = "\\attachments\\examinationResults\\rentgen.pdf",
                    ExaminationId = 3
                }
            };
        }
    }
}
