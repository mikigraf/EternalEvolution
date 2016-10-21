# EternalEvolution
2D roguelike game with MonoGame

## Add new image

1. Copy your image to the folder Content
2. Create an XML file in the folder Load
3. The xml file should contain:
```XML
<?xml version="1.0" encoding="utf-8" ?>
<SplashScreen>
  <Image>
    <Path>splashscreen/lazypandastudios</Path>
    <Position>
      <X>200</X>
      <Y>100</Y>
    </Position>
    <Alpha>1.0</Alpha>
    <Scale>
      <X>4.0</X>
      <Y>4.0</Y>
    </Scale>
  </Image>
</SplashScreen>
```
*For reference on what can be specified in this XML file see the* **Image class** 


