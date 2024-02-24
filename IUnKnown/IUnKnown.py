
import matplotlib.pyplot as plt
import cv2
import easyocr
from pylab import rcParams
from IPython.display import Image
rcParams['figure.figsize'] = 8, 16

reader = easyocr.Reader(['en'])


# Specify the path of your image
image_path = './Images/Samples/Example.png'
Image(image_path)
output = reader.readtext(image_path)
print(output)