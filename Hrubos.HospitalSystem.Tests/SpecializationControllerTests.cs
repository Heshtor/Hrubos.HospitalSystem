using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Domain.Entities;
using Hrubos.HospitalSystem.Web.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace Hrubos.HospitalSystem.Tests
{
    public class SpecializationControllerTests
    {
        // Mocky (falešné závislosti)
        private readonly Mock<ISpecializationAppService> _mockService;
        private readonly Mock<ILogger<SpecializationController>> _mockLogger;

        // Testovaný Controller
        private readonly SpecializationController _controller;

        public SpecializationControllerTests()
        {
            // Inicializace Mocků
            _mockService = new Mock<ISpecializationAppService>();
            _mockLogger = new Mock<ILogger<SpecializationController>>();

            // Vytvoření instance controlleru s falešnými službami
            _controller = new SpecializationController(_mockService.Object, _mockLogger.Object);
        }

        [Fact]
        public void Create_ValidModel_CallsServiceAndRedirects()
        {
            // ARRANGE (Příprava)
            var specialization = new Specialization
            {
                Id = 1,
                Name = "Chirurgie"
            };

            // Nastavení Mocku - metoda Create nebude nic vracet ani házet výjimky
            _mockService.Setup(service => service.Create(It.IsAny<Specialization>()));

            // ACT (Akce)
            var result = _controller.Create(specialization);

            // ASSERT (Ověření)

            // Ověření, že výsledek je RedirectToActionResult (přesměrování)
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);

            // Ověření, že přesměrovává na akci Select
            Assert.Equal(nameof(SpecializationController.Select), redirectResult.ActionName);

            // Ověření, že se skutečně jednou zavolala metoda Create na servise
            _mockService.Verify(service => service.Create(specialization), Times.Once);
        }

        [Fact]
        public void Create_InvalidModel_ReturnsViewWithModelAndNoServiceCall()
        {
            // ARRANGE (Příprava)
            var specialization = new Specialization
            {
                Name = ""
            };

            // Simulujeme chybu validace - ModelState.IsValid bude false
            _controller.ModelState.AddModelError("Name", "Název je povinný");

            // ACT (Akce)
            var result = _controller.Create(specialization);

            // ASSERT (Ověření)

            // Ověření, že výsledek je ViewResult
            var viewResult = Assert.IsType<ViewResult>(result);

            // Ověření, že model ve ViewResult je ten samý jako specialization
            Assert.Equal(specialization, viewResult.Model);

            // Ověření, že metoda Create na servise nikdy nebyla zavolána
            _mockService.Verify(service => service.Create(It.IsAny<Specialization>()), Times.Never);
        }
    }
}
