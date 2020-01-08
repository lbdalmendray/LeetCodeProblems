using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;
using WordBreakII;

namespace WordBreakIITest
{
    [TestClass]
    public class UnitTest1
    {
        EnumerableComparer<string> enumerableComparer = new EnumerableComparer<string>();

        [TestMethod]
        public void TestMyContainer()
        {
            MyContainer container = new MyContainer(new string[] { "a", "aaa", "aaaaa", "aba", "ababa", "bb", "bbbb", "bbbbbb" });
            var result = container.GetValidWordPositions("aaaaaa",0);
            Assert.IsTrue(result.All(e => e % 2 == 0));

            result = container.GetValidWordPositions("bbbbbb", 0);
            Assert.IsTrue(result.All(e => e % 2 == 1));

            result = container.GetValidWordPositions("tt", 0);
            Assert.IsTrue(result.All(e => e % 2 == 0));
        }

        [TestMethod]
        public void TestMyContainerV2()
        {
            MyContainer container = new MyContainer(new string[] { "a", "aaa", "aaaaa", "aba", "ababa", "bb", "bbbb", "bbbbbb" }.Select(e=>e.ToUpper()).ToArray());
            var result = container.GetValidWordPositions("aaaaaa".ToUpper(), 0);
            Assert.IsTrue(result.All(e => e % 2 == 0));

            result = container.GetValidWordPositions("bbbbbb".ToUpper(), 0);
            Assert.IsTrue(result.All(e => e % 2 == 1));

            result = container.GetValidWordPositions("tt".ToUpper(), 0);
            Assert.IsTrue(result.All(e => e % 2 == 0));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.WordBreak("catsanddog", new string[] { "cat", "cats", "and", "sand", "dog" });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "cats and dog", "cat sand dog" }));
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            var result = s.WordBreak("catsanddog".ToUpper(), new string[] { "cat".ToUpper(), "cats".ToUpper(), "and".ToUpper(), "sand".ToUpper(), "dog".ToUpper() });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "cats and dog".ToUpper(), "cat sand dog".ToUpper() }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.WordBreak("cat", new string[] { "cat", "cats", "and", "sand", "dog" });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "cat" }));
        }

        [TestMethod]
        public void TestMethod22()
        {
            Solution s = new Solution();
            var result = s.WordBreak("cat".ToUpper(), new string[] { "cat", "cats", "and", "sand", "dog" }.Select(e => e.ToUpper()).ToArray());
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "cat" }.Select(e => e.ToUpper()).ToArray()));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.WordBreak("pineapplepenapple", new string[] { "apple", "pen", "applepen", "pine", "pineapple" });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "pine apple pen apple",
                  "pineapple pen apple",
                  "pine applepen apple" }));
        }

        [TestMethod]
        public void TestMethod33()
        {
            Solution s = new Solution();
            var result = s.WordBreak("pineapplepenapple".ToUpper(), new string[] { "apple", "pen", "applepen", "pine", "pineapple" }.Select(e => e.ToUpper()).ToArray());
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "pine apple pen apple",
                  "pineapple pen apple",
                  "pine applepen apple" }.Select(e => e.ToUpper()).ToArray()));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.WordBreak("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] {  }));
        }

        [TestMethod]
        public void TestMethod44()
        {
            Solution s = new Solution();
            var result = s.WordBreak("catsandog".ToUpper(), new string[] { "cats", "dog", "sand", "and", "cat" }.Select(e => e.ToUpper()).ToArray());
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { }));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            for (int letterCount = 4; letterCount < 18; letterCount++)
            {
                var fourLetters = CreateAllLettersList(2, letterCount);
                var twoLetters = CreateAllLettersList(4, letterCount);
                var bigList = Enumerable.Concat(fourLetters, twoLetters).ToArray();
               
                var result = s.WordBreak(CreateAllLetters(4, letterCount), bigList);
                Assert.AreEqual(result.Count, (int)Math.Pow(2, letterCount));
            }
            
        }

        [TestMethod]
        public void TestMethod55()
        {
            Solution s = new Solution();
            for (int letterCount = 4; letterCount < 18; letterCount++)
            {
                var fourLetters = CreateAllLettersList(2, letterCount);
                var twoLetters = CreateAllLettersList(4, letterCount);
                var bigList = Enumerable.Concat(fourLetters, twoLetters).ToArray();

                var result = s.WordBreak(CreateAllLetters(4, letterCount).ToUpper(), bigList.Select(e => e.ToUpper()).ToArray());
                Assert.AreEqual(result.Count, (int)Math.Pow(2, letterCount));
            }

        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.WordBreak("cAtsanddog", new string[] { "cAt", "cAts", "and", "sand", "dog" });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "cAt sand dog" , "cAts and dog" }));
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.WordBreak("fkjjlbhkbbefinemajmoebhjbkojmcaehiibankkomghncojbjgedebjfdocjhclmbalebladkcaidacaiiokemdmaabjalmbgggjjfjfedegmnkidceogjdgncmlhodkcmjkfolgfnaklkjbocjhhakgmigkcmilbikbhjcgz", new string[] { "gaggkdeo", "igkcmil", "mfljaieijcjk", "nddenji", "ihkao", "k", "halnhbcmabjb", "aeb", "hmamkhmlfce", "mnkjgjjodida", "gm", "hancobi", "g", "hmoafjnono", "meanolmbloog", "nochomliagledo", "ahdimafaacc", "necn", "goicmonlkil", "jfigiglloi", "jjfjfede", "akgjlbgjldec", "oooij", "dk", "elbofj", "mmddfkfig", "kaklf", "bcbeenfeee", "ajkooijb", "oaanehdai", "e", "omk", "mfmed", "iheidmbjeinfebk", "bikbhjcg", "eh", "hmbneijnk", "cccganlndjo", "igfmdoiihc", "edoncgeohal", "i", "glie", "ncojbjg", "gnmifoifaec", "ncogocd", "kgogljaidon", "dkghjha", "mf", "fmoimobjf", "incmj", "ihiehafnmilce", "hji", "daoklglc", "obbomj", "fh", "f", "mnmbhk", "jaj", "ikbdlhfhk", "lihmboinijkkka", "cda", "boimoc", "iohgjocn", "gaof", "lld", "jhhak", "jhjekma", "jedihdccoojide", "anibenolmjmbf", "ofhaicalhmdcnjd", "c", "egonomcienfh", "ml", "lgekjonkeao", "ddhahngil", "gfmcb", "oiikakdhl", "iab", "jehicc", "jmocmaiokn", "eflmhnglhejd", "ahii", "dmo", "dfdgfnmldhaooae", "nohgoc", "jjlmggdbhno", "odkimohjodbh", "dmhkkgjcjhiid", "fcdgbjgbbm", "mhoomlad", "nbofdoofom", "cencoc", "aefehagm", "nnio", "jjiigmc", "cgel", "ela", "hhd", "jkkddacaam", "b", "mo", "md", "damiock", "ebeao", "mlffgmgbloc", "abgmmnmiijglm", "ibjdnckgfonia", "nn", "mnc", "hijgoeco", "jkgaghmhlnehc", "ieadnfjcoi", "kmjfnjhlabcihe", "gobkj", "cmajffc", "hhbmckl", "fgmghbh", "ehclhidfbfb", "nibjmglgmglhf", "hnblghaejege", "nkkomgh", "fbkfl", "ogdail", "ejehdmbk", "mocmnio", "mlfkgaab", "dijb", "mlbcnljogof", "lnjadlm", "ijgcicndm", "cgnblkchngklbf", "jbebfgk", "hdjg", "dl", "honjckb", "cdomnnhjocaoe", "ebnje", "igkgjalnbhinghi", "iojginhi", "fmmdnnjobikond", "jeflgnl", "noodabd", "ojgd", "nfkjdggjn", "kajbdaikidneidm", "klbjfcfjlkcibba", "geecdcfbkede", "ndjbgdadje", "mokfehacdd", "mjdkenofkaeli", "mcmnj", "mfggccd", "nmonjefcjolhfgg", "amdfecagjfkfdh", "kbijncaeoon", "febfhfjgkhdab", "bgglmgmkjhne", "mhhojoihflf", "dfaffjcdnchb", "mnh", "fjcikedcd", "odd", "j", "kjafgaiklcemkcd", "lnhgochigmcgk", "fnhijgnend", "gniekccclcn", "ofggcjlidbjeh", "aojegacnehgbdgc", "bbabogkdekleei", "egcmokhdio", "inl", "fleeid", "mmdcekhihfc", "ckbbhaaoakfe", "nadbaeddfjej", "finiacgd", "khid", "haaiani", "hekleijlafocdh", "jihfh", "aolhnacokig", "nnggoafjl", "fkhjghiaeojhi", "oan", "aajimcikcnaebe", "achigecoboif", "cjhed", "ijhg", "oonjh", "allhnelgjdl", "abh", "cabncchfmbn", "khnciickdoehol", "jnof", "bfmalenhf", "bckmd", "haln", "iaiffadaadji", "hoadjf", "nagchlghjhk", "hjlbacedkkdnk", "ace", "bmldoimodegcl", "mdiojfhgmfg", "omkblifelkfifjn", "amnldcmobkkjmkj", "iaibe", "efnn", "nmbf", "a", "foenajo", "jgnkhn", "ncagcgnfcfm", "confnibafdeiiad", "cdjgakfn", "lmh", "nlabndn", "n", "kc", "gddjoojoeomanj", "kmf", "hj", "jgnijhekbmbcbk", "gjhfei", "bfiladjlggjjh", "fckgfmdeikdkkfi", "abnldlg", "fgnnjefaegg", "mochafeafehelb", "ncbdkecddnegbko", "ceedljkegf", "okhdgjkao", "dfdcocheclaaj", "ladkcaida", "klfkbnbjeg", "bihmahlknalkbb", "gobo", "edggcafghgbokfg", "lfcdahkamfnnlbe", "fhobdnbh", "fllibcljdmajn", "obhlnghf", "njbcm", "kmkbnlldhadfc", "ghmk", "ijbeihkojjml", "clmbaleb", "offmicbgejkh", "hmmjfbkh", "jkfehdlek", "gbk", "gmocchifcgmofhd", "lbc", "anicc", "ejhddgheln", "nemajmoebhjbkoj", "naemi", "nnenmabkhlm", "bjhb", "jmjhmnjkgh", "admjcjbca", "llem", "hkbbe", "nmdjmkjhdja", "koniblnljgmmbbg", "biljfalmflchb", "dblnhfib", "ok", "emilcjdncm", "ilfkbiodab", "eoohdfhno", "dgd", "o", "mbjj", "legdidaoclb", "nghlkbkbbljh", "ekabk", "ggkgfkbomme", "ogfmlfcaklef", "ikgg", "kghbdjieniho", "noighlblehf", "jfmgihkonmbm", "bimicdfhlifg", "klimcfnojbiooc", "lakbda", "mkcoboaddi", "nfaebmd", "fbjlahcaajamjaj", "gncllkii", "fboglhliehal", "jk", "ocimnaceklgmoe", "fcnh", "ohcnnkamoaom", "ccimaiofdealnjf", "mkdanlkeekecc", "hamboelbcdbai", "lbljfeianmkhon", "bhjbndfffcdhm", "nafgoeceilmebn", "jmb", "fmmfmdmnigllb", "dbaobkconcfcan", "ajdibacdfg", "iknhfe", "abdaeca", "l", "becafg", "eeieaeoiaagjbdi", "odgfeca", "anbceegkdn", "bknkeonigb", "fj", "kacanki", "jlkoncijbo", "kaeobkadncbgn", "eagocnmnjjhnlmh", "adnnllieng", "imlkbgfmolmj", "nlmnkngheaof", "kcockjm", "ggmfbilldo", "abagjicencjdhh", "gedckmkehn", "ijecleakkbndgl", "joifkiccb", "aiameogbecidakj", "jdaiilnfh", "kgdond", "bnecbmebab", "mfmlijibjdcoddh", "nlcbiiejklclf", "jlijddomde", "gniiehcllnm", "amj", "fbcclace", "ainmcmmhbc", "cglfdaklhmmocl", "hfkfdfkmlkai", "hkfjjhejacc", "kgm", "anbhgnjhjfabiok", "bdhmgigjbj", "dokmfnldohbgk", "cg", "bgmkhfd", "dfj", "gjhd", "idkmgmmnaejkdel", "gekmbmmn", "hccecjfbfij", "cfek", "fjeoegjlmligac", "alhnjlacob", "liedbjcj", "adlif", "okddmo", "lgbkmbek", "oobncia", "moobambifbljk", "gakogkghmihooak", "hllhgdamoiej", "lfkjddl", "mjfb", "ibngnkbicenfga", "dombgn", "kjboc", "hdamjncmdol", "hicl", "obocccgm", "ccomeiofkjnknga", "acflfadojem", "kl", "odkcmjkfolgfnak", "jlennlehfii", "biimao", "ghmaeadafbj", "coggdjg", "cdnchammeiegom", "lofmfgelbmlehnc", "jialklmcdlohkm", "jbimboeijnbmgol", "nndgm", "hebjao", "cijlobchgka", "hljojiclje", "gdb", "kamgaigodfcbk", "mi", "lcjalnfojcmjbl", "mdkmocngibmgnjb", "fobhhgdf", "dekdcobbeghi", "elofjhgeackijdk", "abjal", "glnnkdccgi", "kbcjlljgdnnbmi", "bg", "jnoffjafmaa", "h", "knhefdjjlaife", "nbalab", "jkhd", "neaofeanlcidni", "bdckcnlkbo", "fkj", "ihlknj", "iggdjfk", "nmmkjg", "jhmimaem", "minieag", "fofgj", "jafebbgi", "cbanbcaknggl", "nkncbcjlidilefo", "filngail", "oocb", "hdhliiikjfhm", "hfmaiekfb", "af", "hfjemfchd", "hainei", "mehfggjbghiomni", "lcjnmbclgbin", "djeokdahia", "lh", "lfbfoj", "aohgcfcmbhmek", "clfbgjichnmfa", "chieogij", "fglg", "accifaokkgmnb", "iamjljccnihcn", "idocdnlj", "dh", "clhmcifbgcjf", "bjmlcfhdjocgl", "nbhajeoi", "adeaadndhie", "mlheaedi", "jdbgkfadelbejhg", "ohlecggkboamn", "boinmneifn", "angj", "hoclbcdofng", "gkjcegiifa", "lakke", "gfa", "nnimh", "iikjgcmfbagd", "fefgjd", "eeboefdackceb", "mmkccjei", "hloiook", "hcge", "gmhncohdjkk", "clmkcojajn", "ogjdgncmlh", "dfookkmceiigmh", "fhkjcimkiofoinn", "mjahgdgnabdj", "hb", "obkkbdcjglm", "le", "cmninbjdhekcb", "oodikoamlelcne", "bnbafkkddmk", "neagoocl", "bhmdmlejaiji", "mjlbealgl", "cafnnmniln", "labfg", "leelb", "ocifbibijfgdk", "dbbb", "ghbmcg", "mom", "igo", "jcmfoebajefjdi", "iikgmjn", "obnckkadabjhfi", "lhekmhildjkcn", "njfogfnj", "fcgacdhcclde", "ichaeligmk", "hmcjoigoea", "cc", "ickfcelfilkbk", "ch", "jkakkdlh", "fkjjlb", "dkcknlo", "lc", "nklohjhjif", "jhgkjjfcjefc", "kalkc", "meglmnhlnem", "lnbmmcbdgfkeem", "ejkbobfilcnafel", "lk", "jlbncfd", "eblmooggngamof", "okmmomdmief", "dahc", "ackmjhnmfgaoafa", "fmjgi", "dbmflmfkdia", "aeajncek", "ehalibdilikeok", "mnjojhdjngin", "m", "hfdlmjjcfmacb", "ekciad", "dkdfmnieiahio", "nihfnbekbhk", "okj", "mmjf", "anfjk", "kocaoh", "amfcflnla", "jealekjf", "fgokkddmfa", "ffbbabn", "okldhifhnhbm", "edmaga", "ajahiocomhbablk", "danmbn", "ilcjcheddnabll", "ochfblfeldbo", "ignhkon", "meiailaib", "aheodadm", "dec", "ianoghmba", "bni", "cenegah", "jcnkiciendihdih", "kegkcmnkh", "fi", "aeldnnmcbilelg", "emejaicfjhafod", "jjonddlecfgdm", "elkcmmlfbiemeg", "edebjfdocjh", "ankghmibmgd", "afmmgmi", "afliaf", "aecckchdf", "mcnhfojki", "la", "blbaif", "bifj", "nkidce", "ddhigddihlkm", "bgjnn", "haclkkjbjdjn", "mcaehiiba", "iebnfadil", "kfgjab", "bafdkg", "gnbbgilljiacl", "fdajjg", "caiiokemdma", "adfchcjninhho", "meaaf", "jahifegbhjj", "hbhgkdl", "egomnbc", "ooccmbmicehi", "afaecdcbjgf", "mcaedecih", "ihjnbgacjahfmj", "hcnco", "hbecolgk", "jdknfnmjehoc", "mnmbndjkono", "mk", "kmmcjjeab", "lekbo", "mcbaknmkcnebj", "mbggg", "men", "jn", "hgcchmkje", "ncnlijanmcog", "hll", "jlhkhiggelnkhbk", "bnoaah", "enainmmdaamaicn", "jieio", "anadihbcbg", "ligl", "fmjkjmgmjmlonel", "gifkkbkedeno", "hmklhikf", "jeoll", "kbhi", "cnkihoga", "ihkndcibcgl", "deogdlmcbc", "mocghlg", "gkaihhoa", "miibddoebolibnc", "ggecjoiodklb", "nafdahhn", "meboilne", "olkhhkledm", "hdklcdfmne", "aclj", "migeheccjgod", "cejnilnhfadml", "mfkmacdgomhcalm", "faijmldniblnl", "mmfcln", "lhmdehaho", "hcj", "fkconhlmknloccn", "hckhl", "lheki", "blenkofhj", "bhjjgkmblen", "dndjigjgikb", "jnjamjglhim", "hg", "bnlbgllnkfemfgj", "ll", "hjekhnhnoam", "mldahadgmegj", "dmj", "henklighfkah", "lcl", "lobhgifjflgcicc", "chnfjdeije", "jbaedijcdm", "jcinegma", "oojiijjcdh", "bkejicnojmlj", "jncnoc", "embdomh", "chkjonad", "eekgln", "aodogkkmodaoc", "ee", "ngnmdfldf", "eajlnmjeckeek", "lnnaiggam", "hlohol", "nibflancimmfk" });
            //Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "cAt sand dog", "cAts and dog" }));
        }

        private string CreateAllLetters(int length, int letterCount)
        {
            string result = "";
            for (int i = 0; i < letterCount; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result += ((char)(i + 'a'));
                }
            }

            return result;
        }

        private LinkedList<string> CreateAllLettersList(int length, int letterCount)
        {
            LinkedList<string> result = new LinkedList<string>();
            for (int i = 0; i < letterCount; i++)
            {
                var resultString = "";
                for (int j = 0; j < length; j++)
                {
                    resultString += ((char)(i + 'a'));
                }
                result.AddLast(resultString);
            }

            return result;
        }
    }
}
