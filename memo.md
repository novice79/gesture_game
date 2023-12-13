## 那天突发奇想，为何没有手机版的wow
##### *2019-10-31*   
<br />
记得以前wow有一、二十个技能，两排技能栏都摆满了，键盘左半边按键不够用，还要绑shift/alt+XXX的快捷键，因为一般都是用左手键盘，右手鼠标这样操作的。后面手机大量普及后，很多人都在等wow移植到移动端，结果一直没实现。我想除了体积太大（几十G）之外——但只用60前的场景与模型的话也就几个G，手机完全可以装下，主要就是操作方式难以移植，因为没法在屏幕上摆十几个按钮，更别说还要旋转摄像头观察左、右、后方的操作。像当前流行的XXXX游戏，都是在手机左边摆个虚拟方向盘，右边摆几个技能按钮，搞的像80年代红白机的手柄似的，除了没压感之外。     
我想手机操作模式无非就是声控跟手势。先实验一下声控，在网上找了一个卡内基·梅隆的<a href='https://cmusphinx.github.io/'>sphinx</a>库，这个库可以训练自定义发音的，比如你说“向前奔跑”、“旋风斩”，只要训练成模型了加载进去，再说这句话它就会识别。我用了一个<a href='https://www.politepix.com/openears/'>openears</a>的ios SDK读取/辨析sphinx训练的句子，再用<a href='https://www.blend4web.com/'>blend4web</a>加载游戏角色模型和动画，这样就能用声音控制角色移动和技能施放了。实验效果是：安静环境下，大多数情况能控制，但在有噪音的环境容易误判。所以声控并不实用，因为没法控制周围环境。再试一下手势操控。     
安卓有一个GestureOverlayView可以识别自定义手势，但我不想绑定在Android平台，就像什么“小程序”只能在XX环境中运行一样，我想要在像浏览器这种omnipresent的环境中运行。找到一个华盛顿大学+微软工程师开发的一个<a href='http://depts.washington.edu/acelab/proj/dollar/index.html'>$1</a>，把其中的js库拿出来再自己加了点垃圾代码，就可在h5的canvas里用了。        
然后用什么webgl库加载3D模型呢，用<a href='https://threejs.org/'>threejs</a>还是<a href='https://www.blend4web.com/'>blend4web</a>？现在大多数人都用unity，虽然笨重了点但确实好用，就用unity写控制逻辑吧，再导出为webgl。把<a href='http://depts.washington.edu/acelab/proj/dollar/index.html'>$1</a>的canvas叠加到unity的webgl div上，用vuejs做手势设置和帮助界面，这样一个【<a href='http://depts.washington.edu/acelab/proj/dollar/index.html'>$1</a>+unity+vue】的spa 3D网站就出来了。问题是这个网站太大，十几兆（血精灵模型+10个fbx动画），没人会等几分钟去打开一个网站，主要是现在网速太慢，可能等以后网速再提高10倍，3D网站才会普及。那就用cordova打包成安卓app吧，实际上打包成ios或其它平台的app都行。    

有人可能会说画手势太慢，没有按键快。但技能是有cd的，又不是按的越快就能施放更多技能。公共cd一秒，如果双持长柄武器，普通攻击都要2秒，就算是拿匕首，普攻一般都是近身自动触发的，也不需要按键。一般技能cd一、二十秒，大招2、3分钟，画一个手势1秒钟，也不存在太慢的问题。
