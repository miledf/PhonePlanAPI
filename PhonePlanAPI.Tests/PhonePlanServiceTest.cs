using Moq;
using PhonePlanAPI.Data;
using PhonePlanAPI.Models;
using PhonePlanAPI.Services;

namespace PhonePlanAPI.Tests
{
    [TestClass]
    public class PhonePlanServiceTest
    {
        private readonly PhonePlanService _phonePlanService;
        private readonly Mock<PhonePlanRepository> _mockPhonePlanRepository;

        public PhonePlanServiceTest()
        {
            _mockPhonePlanRepository = new Mock<PhonePlanRepository>();
            _phonePlanService = new PhonePlanService(_mockPhonePlanRepository.Object);
        }

        [TestMethod]
        public void MustReturnEmptyAllPhonePlansWhenNotExistPhonePlans()
        {
            _mockPhonePlanRepository.Setup(x => x.GetAll()).Returns(new List<PhonePlan>());

            var result = _phonePlanService.GetAllPhonePlans();

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void MustReturnAllPhonePlansWhenExistPhonePlans()
        {
            var phonePlans = new List<PhonePlan>() {
                new PhonePlan{
                    Id = 1,
                    Minutes = 100,
                    Internet = 100,
                    Value = 0.99m,
                    IdPlanType = 1,
                    IdOperator = 1,
                    DDDs = new List<PlanDDD>() {
                        new PlanDDD() { Id = 1, IdDDD = 11 },
                        new PlanDDD() { Id = 2, IdDDD = 21 },
                        new PlanDDD() { Id = 3, IdDDD = 48 }
                    }
                },
            };


            _mockPhonePlanRepository.Setup(x => x.GetAll()).Returns(phonePlans);

            var result = _phonePlanService.GetAllPhonePlans().ToList();

            Assert.AreEqual(1, result.Count());

            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(100, result[0].Minutes);
            Assert.AreEqual(100, result[0].Internet);
            Assert.AreEqual(0.99m, result[0].Value);
            Assert.AreEqual(1, result[0].IdPlanType);
            Assert.AreEqual(1, result[0].IdOperator);

            Assert.AreEqual(3, result[0].DDDs.Count());
            Assert.AreEqual(11, result[0].DDDs[0]);
            Assert.AreEqual(21, result[0].DDDs[1]);
            Assert.AreEqual(48, result[0].DDDs[2]);

        }

        [TestMethod]
        public void MustReturnEmptyAllPhonePlansWhenNotExistPhonePlansByDD()
        {
            _mockPhonePlanRepository.Setup(x => x.GetAllByDDD(It.IsAny<int>())).Returns(new List<PhonePlan>());

            var result = _phonePlanService.GetAllPhonePlans();

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void MustReturnAllPhonePlansWhenExistPhonePlansByDDD()
        {
            var phonePlans = new List<PhonePlan>() {
                new PhonePlan{
                    Id = 1,
                    Minutes = 100,
                    Internet = 100,
                    Value = 0.99m,
                    IdPlanType = 1,
                    IdOperator = 1,
                    DDDs = new List<PlanDDD>() {
                        new PlanDDD() { Id = 1, IdDDD = 11 },
                        new PlanDDD() { Id = 2, IdDDD = 21 },
                        new PlanDDD() { Id = 3, IdDDD = 48 }
                    }
                },
            };


            _mockPhonePlanRepository.Setup(x => x.GetAllByDDD(It.IsAny<int>())).Returns(phonePlans);

            var result = _phonePlanService.GetAllPhonePlansByDDD(48).ToList();

            Assert.AreEqual(1, result.Count());

            Assert.AreEqual(1, result[0].Id);
            Assert.AreEqual(100, result[0].Minutes);
            Assert.AreEqual(100, result[0].Internet);
            Assert.AreEqual(0.99m, result[0].Value);
            Assert.AreEqual(1, result[0].IdPlanType);
            Assert.AreEqual(1, result[0].IdOperator);

            Assert.AreEqual(3, result[0].DDDs.Count());
            Assert.AreEqual(11, result[0].DDDs[0]);
            Assert.AreEqual(21, result[0].DDDs[1]);
            Assert.AreEqual(48, result[0].DDDs[2]);

        }

        [TestMethod]
        public void MustReturnEmptyAllPhonePlansWhenExistPhonePlansByDDDNotExist()
        {
            var phonePlans = new List<PhonePlan>() {
                new PhonePlan{
                    Id = 1,
                    Minutes = 100,
                    Internet = 100,
                    Value = 0.99m,
                    IdPlanType = 1,
                    IdOperator = 1,
                    DDDs = new List<PlanDDD>() {
                        new PlanDDD() { Id = 1, IdDDD = 11 },
                        new PlanDDD() { Id = 2, IdDDD = 21 },
                        new PlanDDD() { Id = 3, IdDDD = 48 }
                    }
                },
            };

            var dddNotExistent = 41;

            _mockPhonePlanRepository.Setup(x => x.GetAllByDDD(48)).Returns(phonePlans);
            _mockPhonePlanRepository.Setup(x => x.GetAllByDDD(21)).Returns(phonePlans);
            _mockPhonePlanRepository.Setup(x => x.GetAllByDDD(11)).Returns(phonePlans);

            var result = _phonePlanService.GetAllPhonePlansByDDD(dddNotExistent).ToList();

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public async Task MustPostAPhonePlan()
        {
            var phonePlan = new PhonePlanDTO
            {
                Id = 1,
                Minutes = 100,
                Internet = 100,
                Value = 0.99m,
                IdPlanType = 1,
                IdOperator = 1,
                DDDs = new List<int>() { 11, 21, 48 }
            };

            await _phonePlanService.PostAsync(phonePlan);

            _mockPhonePlanRepository.Verify(x => x.Post(It.IsAny<PhonePlan>()), Times.Once);
        }

        [TestMethod]
        public async Task MustUpdateAPhonePlan()
        {
            var phonePlan = new PhonePlanDTO
            {
                Id = 1,
                Minutes = 100,
                Internet = 100,
                Value = 0.99m,
                IdPlanType = 1,
                IdOperator = 1,
                DDDs = new List<int>() { 11, 21, 48 }
            };

            var phonePlanReturn = new PhonePlan
            {
                Id = 1,
                Minutes = 100,
                Internet = 100,
                Value = 0.99m,
                IdPlanType = 1,
                IdOperator = 1
            };

            _mockPhonePlanRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(phonePlanReturn);

            await _phonePlanService.UpdateAsync(phonePlan.Id, phonePlan);

            _mockPhonePlanRepository.Verify(x => x.Update(It.IsAny<PhonePlan>()), Times.Once);
        }

        [TestMethod]
        public async Task MustRemoveAPhonePlan()
        {
            var phonePlan = new PhonePlan
            {
                Id = 1,
                Minutes = 100,
                Internet = 100,
                Value = 0.99m,
                IdPlanType = 1,
                IdOperator = 1
            };

            _mockPhonePlanRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(phonePlan);

            await _phonePlanService.RemoveAsync(1);

            _mockPhonePlanRepository.Verify(x => x.RemoveAsync(It.IsAny<PhonePlan>()), Times.Once);
        }

        [TestMethod]
        public async Task MustGetByIdAPhonePlan()
        {
            var phonePlan = new PhonePlan
            {
                Id = 1,
                Minutes = 100,
                Internet = 100,
                Value = 0.99m,
                IdPlanType = 1,
                IdOperator = 1
            };

            _mockPhonePlanRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(phonePlan);

            var result = await _phonePlanService.GetById(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(100, result.Minutes);
            Assert.AreEqual(100, result.Internet);
            Assert.AreEqual(0.99m, result.Value);
            Assert.AreEqual(1, result.IdPlanType);
            Assert.AreEqual(1, result.IdOperator);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task ThrowExceptionWhenNotExistPhonePlanWhenRemoving()
        {
            _mockPhonePlanRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(() => null);

            await _phonePlanService.RemoveAsync(1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public async Task ThrowExceptionWhenNotExistPhonePlanWhenUpdating()
        {
            var phonePlan = new PhonePlanDTO
            {
                Id = 1,
                Minutes = 100,
                Internet = 100,
                Value = 0.99m,
                IdPlanType = 1,
                IdOperator = 1,
                DDDs = new List<int>() { 11, 21, 48 }
            };

            _mockPhonePlanRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(() => null);

            await _phonePlanService.UpdateAsync(phonePlan.Id, phonePlan);
        }
    }
}