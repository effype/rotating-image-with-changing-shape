# Rotating image with changing shape in GDI
The ellipse changes its shape when it rotate. 
I used timer to rotate image.

<code>
 _angle = _sw.Elapsed.TotalSeconds * 40;
 
  var newBitmap = RotateImage(_originalBitmap, (float)_angle);
</code>

You can rotate a ellipse to specyfic angle

<code>
_angle = 270;
</code>
Results for rotation and changing shape of ellipse 

<a href="https://i.gyazo.com/d15bfa3a84d98716f52338430bf0a39b.mp4"> Animation </a>

For changing shape 
<code> fromImage.ScaleTransform(0.9F, 0.6F); </code>

Bicubic interpolation

<code> fromImage.InterpolationMode = InterpolationMode.HighQualityBicubic; </code>
