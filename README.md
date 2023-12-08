## 演示用手势操作WOW游戏角色的demo


<div style="display:flex;flex-wrap: wrap;align-items: center;justify-content: center;">
    <img style="margin:1.0em;" src="https://github.com/novice79/gesture_game/releases/download/v1.0-gg/gg.gif"></img>
    <img style="margin:1.0em;" src="https://github.com/novice79/gesture_game/releases/download/v1.0-gg/Screenshot_20191031-220744.jpg" />
</div>

[演示视频（2.6M）](https://github.com/novice79/gesture_game/releases/download/v1.0-gg/gg.mp4)

**[App下载（15.8M）](https://github.com/novice79/gesture_game/releases/download/v1.0-gg/gg.apk)**

### 编译步骤
1. 安装unity，打开unity目录下的工程编译成webgl
2. 把编译好的webgl Build目录拖到 vue/public目录下
3. 编译vue工程，cd vue && npm i && npm run build
4. 编译好的3D网站会生成在cordova/www目录下   
如果不需要打包成app，直接把这个目录丢到某个nginx虚拟站点目录下当静态网站，用手机访问测试即可。
5. 如果需要打包成安卓app，请参考cordova官方文档安装Android编译环境。  
然后cd cordova && cordova build android ，即可生成apk安装包。
