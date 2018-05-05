﻿using FlightNode.DataCollection.Domain.Entities;
using FlightNode.DataCollection.Services.Models.Survey;
using FligthNode.Common.Api.Controllers;
using Moq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace FlightNode.DataCollection.Domain.UnitTests.Services.Controller.WaterbirdForagingSurveyControllerTests
{


    public class WhenCreatingAForagingSurvey
    {

        public class HappyPath : Fixture
        {

            [Fact]
            public void MapsPrepTimeHours()
            {
                RunPositiveTest();

                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => PrepTime == y.PrepTimeHours)));
            }

            [Fact]
            public void MapsWindDirection()
            {
                RunPositiveTest();

                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => WindDirection == y.WindDirection)));
            }

            [Fact]
            public void MapsWaterHeightId()
            {
                RunPositiveTest();

                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => WaterHeightId == y.WaterHeightId)));
            }

            [Fact]
            public void MapsAccessPoint()
            {
                RunPositiveTest();

                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => ACCESS_POINT == y.AccessPointId)));
            }

            [Fact]
            public void MapsDisturbanceComment()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DISTURBED == y.DisturbanceComments)));
            }


            [Fact]
            public void MapsEndDate()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DateValuesAreClose(END_DATE, y.EndDate.Value))));
            }

            [Fact]
            public void MapsShortEndDate()
            {
                RunPositiveTest(true);
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DateValuesAreClose(END_DATE, y.EndDate.Value))));
            }

            [Fact]
            public void MapsStartDate()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DateValuesAreClose(START_DATE, y.StartDate.Value))));
            }

            [Fact]
            public void MapsShortStartDate()
            {
                RunPositiveTest(true);
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DateValuesAreClose(START_DATE, y.StartDate.Value))));
            }

            [Fact]
            public void MapsLocationId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => LOCATION_ID == y.LocationId)));
            }


            [Fact]
            public void MapsSiteTypeIdToAssessment()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => SITE_TYPE_ID == y.AssessmentId)));
            }

            [Fact]
            public void MapsSurveyCommentsToGeneralComments()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => SURVEY_COMMENTS == y.GeneralComments)));
            }

            [Fact]
            public void MapsTemperature()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => TEMPERATURE == y.Temperature)));
            }

            [Fact]
            public void MapsTide()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => WindDrivenTide == y.WindDrivenTide)));
            }

            [Fact]
            public void MapsVantagePoint()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => VANTAGE_POINT == y.VantagePointId)));
            }

            [Fact]
            public void MapsWeather()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => WEATHER == y.WeatherId)));
            }

            [Fact]
            public void MapsWindSpeed()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => WindSpeed == y.WindSpeed)));
            }

            [Fact]
            public void MapsDisturbedBehavior()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DISTURBED_BEHAVIOR == y.Disturbances.First().Result)));
            }

            [Fact]
            public void MapsDisturbanceTypeId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DISTURBED_TYPE_ID == y.Disturbances.First().DisturbanceTypeId)));
            }

            [Fact]
            public void MapsDisturbanceId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DISTURBANCE_ID == y.Disturbances.First().Id)));
            }

            [Fact]
            public void MapsDisturbanceDuration()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DISTURBED_DURATION == y.Disturbances.First().DurationMinutes)));
            }

            [Fact]
            public void MapsDisturbanceQuantity()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => DISTURBED_QUANTITY == y.Disturbances.First().Quantity)));
            }

            [Fact]
            public void MapsIdentifierIntoDisturbance()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => IDENTIFIER == y.Disturbances.First().SurveyIdentifier)));
            }

            [Fact]
            public void MapsObserver()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => Observers == y.Observers)));
            }

            [Fact]
            public void MapsIdentifierIntoObservation()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => IDENTIFIER == y.Observations.First().SurveyIdentifier)));
            }

            [Fact]
            public void MapsObservationId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => OBSERVATION_ID == y.Observations.First().Id)));
            }

            [Fact]
            public void MapAdultsToBin1()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => ADULTS == y.Observations.First().Bin1)));
            }


            [Fact]
            public void MapJuvenilesToBin2()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => JUVENILES == y.Observations.First().Bin2)));
            }

            [Fact]
            public void MapPrimaryBehavior()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => PRIMARY_ACTIVITY_ID == y.Observations.First().PrimaryActivityId)));
            }

            [Fact]
            public void MapSecondaryBehavior()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => SECONDARY_ACTIVITY_ID == y.Observations.First().SecondaryActivityId)));
            }

            [Fact]
            public void MapSpeciesId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => SPECIES_ID == y.Observations.First().BirdSpeciesId)));
            }

            [Fact]
            public void MapsFeedingId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => FEEDING_ID == y.Observations.First().FeedingSuccessRate)));
            }

            [Fact]
            public void MapsHabitatId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => HABITAT_ID == y.Observations.First().HabitatTypeId)));
            }

            [Fact]
            public void MapsSurveyTypeId()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => SurveyType.Foraging == y.SurveyTypeId)));
            }



            public override void Dispose()
            {
                // Restore delegate extension method to default behavior
                ExtensionDelegate.Init();

                base.Dispose();
            }

            [Fact]
            public void MapsSubmittedBy()
            {
                RunPositiveTest();
                MockDomainManager.Verify(x => x.Create(It.Is<SurveyPending>(y => SubmittedBy == y.SubmittedBy)));
            }


            [Fact]
            public void RespondsWithCreated()
            {
                var result = RunPositiveTest() as CreatedNegotiatedContentResult<WaterbirdForagingModel>;

                //
                // Assert
                Assert.NotNull(result);
            }

            [Fact]
            public void RespondsWithLocation()
            {
                var expected = url + IDENTIFIER.ToString();

                var result = RunPositiveTest() as CreatedNegotiatedContentResult<WaterbirdForagingModel>;

                //
                // Assert
                Assert.Equal(expected, result.Location.ToString());
            }

            private IHttpActionResult RunPositiveTest(bool useShort = false)
            {
                //
                // Arrange
                WaterbirdForagingModel input = CreateDefautInput();

                if (useShort)
                {
                    input.StartDate = StartDateStringShort;
                    input.StartTime = StartTimeStringShort;
                    input.EndTime = EndTimeStringShort;
                }

                MockDomainManager.Setup(x => x.NewIdentifier())
                    .Returns(IDENTIFIER);

                MockDomainManager.Setup(x => x.Create(It.IsAny<SurveyPending>()))
                    .Returns((SurveyPending actual) => actual);


                var system = BuildSystem();

                //
                // Act
                return system.Post(input);
            }


        }

        public class ExceptionHandling : Fixture
        {

            private HttpResponseMessage RunTest(Exception ex)
            {
                MockDomainManager.Setup(x => x.NewIdentifier())
                    .Returns(IDENTIFIER);
                MockDomainManager.Setup(x => x.Create(It.IsAny<SurveyPending>()))
                    .Throws(ex);


                return BuildSystem().Post(CreateDefautInput()).ExecuteAsync(new System.Threading.CancellationToken()).Result;
            }

            [Fact]
            public void NullInputShouldBeTreatedAsABadRequest()
            {

                var result = BuildSystem().Post(null).ExecuteAsync(new System.Threading.CancellationToken()).Result;

                Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            }
        }
    }
}
