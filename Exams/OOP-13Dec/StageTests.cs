// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
        }
		[Test]
	    public void When_StageIsCreateSPerformersCount_ShouldBeZero()
	    {
			Assert.AreEqual(0, stage.Performers.Count);
		}
		[Test]
		public void AddPerformer_Should_ThrowsException_WhenPassedInvalidData()
        {
			Performer performer = null;
			Assert.Throws<ArgumentNullException>(()=>stage.AddPerformer(performer));
        }
		[Test]
		public void AddPerformer_Should_ThrowsException_WhenAgeLessThan18()
        {
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Da", "da", 17)));
        }
		[Test]
		[TestCase(18)]
		[TestCase(19)]
		public void AddPerformer_ShouldIncreaseCount_WhenPassedValidPerformer(int age)
		{
			stage.AddPerformer(new Performer("da", "ne", age));
			int expected = stage.Performers.Count;
			Assert.AreEqual(1, expected);
		}
		[Test]
		public void AddSong_Should_ThrowException_WhenPassedInvalidSong()
		{
			Song song = null;
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
		}
		[Test]
		public void AddSong_Should_ThrowsException_WhenTotalTimeIsLessThanOne()
		{
			TimeSpan time = new TimeSpan(0,0,0);
			Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("mix", time)));
		}
		[Test]
		public void AddSong_Should_CorrectlyWork_WhenTotalTimeIsBiggestOrEqualToOne()
        {
			TimeSpan time = new TimeSpan(0,1,0);
			Song song = new Song("mix", time);
			Performer performer = new Performer("Trix", "bix", 19);
			stage.AddSong(song);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer("mix", "Trix bix");
			Assert.AreEqual(true, stage.Performers.Any(p => p.SongList.Contains(song)));
		}
		[Test]
		public void AddSongToPerformer_ShouldWorkCorrctly_WhenPassedValidData()
        {
			this.stage.AddPerformer(new Performer("da", "ne", 20));
			this.stage.AddSong(new Song("mix", new TimeSpan(0, 2, 0)));
			string result = this.stage.AddSongToPerformer("mix", "da ne");
			string expected = "mix (02:00) will be performed by da ne";
			Assert.AreEqual(expected, result);
		}
		[Test]
		public void AddSongToPerformer_Should_ThrowException_WhenPassedInvalidPerformer()
        {
			Assert.Throws<ArgumentNullException>(()=>stage.AddSongToPerformer("mix",null));
        }
		[Test]
		public void AddSongToPerformer_Should_ThrowException_WhenPassedInvalidSong()
		{
			stage.AddPerformer(new Performer("da", "ne", 20));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "da"));
		}
		[Test]
		public void Play_ShouldReturn_Correctly()
        {
			string expected = $"{1} performers played {1} songs";
			stage.AddPerformer(new Performer("TRix", "mix", 21));
			TimeSpan time = new TimeSpan(0, 10, 0);
			stage.AddSong(new Song("dada", time));
			stage.AddSongToPerformer("dada","TRix mix");
			string actual = stage.Play();
			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void da()
        {
			
        }

	}
}