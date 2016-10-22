# EternalEvolution
2D roguelike game for Windows created with MonoGame

## Add new image

>__Warning!__

>__Fonts should be loaded through the content manager!__

1. Copy your image to the folder Content
2. Create an XML file in the folder Load
3. The xml file should contain:
```XML
<?xml version="1.0" encoding="utf-8" ?>
<SplashScreen>
  <Image>
    <!-- Path to the image -->
    <Path>splashscreen/lazypandastudios</Path>

    <!-- Effects -->
    <Effects>FadeEffect</Effects>
    <IsActive>true</IsActive>
    
    <!-- Position -->
    <Position>
      <X>200</X>
      <Y>100</Y>
    </Position>

    <!-- Alpha = Transparency -->
    <Alpha>1.0</Alpha>
    
    <!-- Scale -->
    <Scale>
      <X>4.0</X>
      <Y>4.0</Y>
    </Scale>
  </Image>
</SplashScreen>
```
*For reference on what can be specified in this XML file see the* **Image class** 


