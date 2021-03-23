using System;
using Xunit;



namespace ImdbWebScraper.Tests
{
    public class StripATagTests
    {
        [Fact]
        public void TestATag()
        {
            string testStringInput1 =  "<a href=\"/name/nm0001557\">Viggo Mortensen</a> chipped a tooth while filming a fight sequence. He wanted <a href=\"/name/nm0001392\">Peter Jackson</a> to superglue it back on so he could finish his scene, but Jackson took him to the dentist on his lunch break, had it patched up, and returned to the set that afternoon.";
            string testStringOutput1 = HelperFunctions.StripATags(testStringInput1);
            string testStringExpected1 = "Viggo Mortensen chipped a tooth while filming a fight sequence. He wanted Peter Jackson to superglue it back on so he could finish his scene, but Jackson took him to the dentist on his lunch break, had it patched up, and returned to the set that afternoon.";

            string testStringInput2 =  "Boromir's speech at the Council of Rivendell was read from a sheet of paper sitting on <a href=\"/name/nm0000293\">Sean Bean</a>'s lap, as it was only given to him the night before.";
            string testStringOutput2 = HelperFunctions.StripATags(testStringInput2);
            string testStringExpected2 = "Boromir's speech at the Council of Rivendell was read from a sheet of paper sitting on Sean Bean's lap, as it was only given to him the night before.";

            Assert.Equal(testStringExpected1, testStringOutput1);
            Assert.Equal(testStringExpected2, testStringOutput2);
        }
    }
}
