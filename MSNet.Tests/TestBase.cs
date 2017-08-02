using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using M2SA.AppGenome;
using NUnit.Framework;
using M2SA.AppGenome.Data;
namespace MSNet.Tests
{
    public abstract class TestBase
    {
        Stopwatch stopwatch = null;

        [TestFixtureSetUp]
        public virtual void Start()
        {

            Console.WriteLine("ApplicationHost.GetInstance().BeginStart();");
            stopwatch = Stopwatch.StartNew();
            ApplicationHost.GetInstance().Start();            
            ApplicationHost.GetInstance().Exit += new EventHandler(TestBase_OnExit);
          
        }

        void TestBase_OnExit(object sender, EventArgs e)
        {
            Console.WriteLine("ApplicationHost exit.");
        }

        [TestFixtureTearDown]
        public virtual void Stop()
        {
            Console.WriteLine("ApplicationHost.GetInstance().BeginStop();");
            ApplicationHost.GetInstance().Stop();
            stopwatch.Stop();
            Console.WriteLine("ApplicationHost.GetInstance().StopEnd();");
        }

        public static string BuliderName()
        {
            string[] name = "乔峰,段誉,王语嫣,无眉老祖,老顽童,杨过,小龙女,方证大师,张召重,余鱼同,骆冰,文泰来,陈家洛,徐天宏,周绮,霍青桐,南帝,李莫愁,金轮法王,郭襄,东邪,刀白凤,丁春秋,马夫人,马五德,小翠,于光豪,巴天石,不平道人,邓百川,风波恶,甘宝宝,公冶乾,木婉清,少林老僧,太皇,太后,天狼子,天山童姥,苏星河,苏辙,完颜阿古打,耶律洪基,耶律莫哥,耶律涅鲁古,耶律重元,吴长风,吴光胜,吴领军,辛双清,严妈妈,余婆婆,岳老三,张全祥,单伯山,单季山,单叔山,单小山,单正,段延庆,段正淳,段正明,范禹,范百龄,范骅,何望海,易大彪,郁光标,卓不凡,宗赞王子,哈大霸,姜师叔,枯荣长老,梦姑,姚伯当,神山上人,神音,狮鼻子,室里,项长老,幽草,赵钱孙,赵洵,哲罗星,钟灵,钟万仇,高升泰,一灯大师,子聪,丁大全,人厨子,九死生,马钰,小棒头,大头鬼,马光佐,小王将军,小龙女,尹志平,丘处机,王处一,王十三,公孙止,王志坦,王惟忠,无常鬼,尹克西,天竺僧,少妇,公孙绿萼,孙婆婆,孙不二,皮清云,申志凡,冯默风,讨债鬼,史伯威,史仲猛,史叔刚,史季强,史孟龙,圣因师太,尼摩星,李莫愁,达尔巴,刘处玄,朱子柳,曲傻姑,吕文德,祁志诚,李志常,刘瑛姑,吊死鬼,百草仙,陆鼎立,陆二娘,阿根,张志光,完颜萍,陆冠英,宋德方,陈大方,宋五,沙通天,灵智上人,张君宝,张一氓,陈老丐,张二叔,陆无双,杨过,武三通,武敦儒,武修文,武三娘,林朝英,耶律晋,耶律楚材,耶律燕,忽必烈,丧门鬼,狗头陀,青灵子,欧阳峰,耶律齐,金轮法王,周伯通,洪凌波,点苍渔隐,柔儿,郭破虏,侯通海,觉远大师,俏鬼,柯镇恶,赵志敬,洪七公,郭靖,郭芙,郭襄,姬清玄,笑脸鬼,鹿清笃,崔志方,鄂尔多,萨多,黄药师,黄蓉,程遥迦,鲁有脚,彭连虎,韩无垢,童大海,韩老丐,彭长老,瘦丐,程瑛,雷猛,裘千尺,蒙哥,煞神鬼,催命鬼,蓝天和,裘千仞,赫大通,潇湘子,霍都,樊一翁,藏边大丑,藏边二丑,藏边三丑,藏边四丑,藏边五丑".Split(',');
            int len = name.Length - 1;
            int rnd = new Random().Next(0, len);
            return name[rnd];
        }
    }
}
