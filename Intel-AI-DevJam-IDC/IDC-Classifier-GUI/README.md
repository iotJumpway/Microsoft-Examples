# Invasive Ductal Carcinoma (IDC) Classification Using Computer Vision & IoT
## Intel AI DevJam Demo GUI

![Intel AI DevJam Demo GUI](../IDC-Classifier/images/IDC-Classification.jpg)

## Introduction

The **Intel AI DevJam Demo GUI** project provides the source codes and tutorials for setting up the same project that will demonstrated at **Intel AI DevJam** at **ICML** (**International Conference on Machine Learning**) in **Sweden**, July 2018.

The **Intel® AI DevJam Demo GUI** uses a **Windows application** to communicate with a **facial recognition classifier** and a classifier trained to detect **Invasive Ductal Carcinoma (Breast cancer)** in **histology images**.

## IoT Connectivity

**IoT connectivity** for the project is provided by the [IoT JumpWay](https://www.iotjumpway.tech "IoT JumpWay"). The **IoT JumpWay** is an **IoT communication** platform as a service (PaaS) with a social network frontend. IoT JumpWay developers will soon be able to share projects/photos/videos and events. Use of the IoT JumpWay is completely free, you can find out more on the [Developer Program](https://iot.techbubbletechnologies.com/developers/ "Developer Program") page.

## Checklist

Make sure you have completed the following steps before continuing to configure the Universal Windows Application. 

- Setup the [IDC classification server/API](https://github.com/iotJumpway/IoT-JumpWay-Microsoft-Examples/tree/master/Intel-AI-DevJam-IDC/IDC-Classifier "IDC classification server/API").

- Setup the [IoT alarm device](https://github.com/iotJumpway/IoT-JumpWay-Microsoft-Examples/tree/master/Intel-AI-DevJam-IDC/Dev-Kit-IoT-Alarm "IoT alarm device").

## Software Requirements

- [Microsoft Visual Studio 2017](https://www.visualstudio.com/downloads/ "Microsoft Visual Studio 2017")

## Setting Up The Universal Windows Application

![IDC Classifier Universal Windows Application](images/VS2017-Universal-Windows-App.jpg)

You should have already downloaded the repository source code when you completed the [IDC classification server/API](https://github.com/iotJumpway/IoT-JumpWay-Microsoft-Examples/tree/master/Intel-AI-DevJam-IDC/IDC-Classifier "IDC classification server/API") setup. Navigate to **IoT-JumpWay-Microsoft-Examples/Intel-AI-DevJam-IDC** and double click the **IDC-Classifier-GUI.sln** file to open the solution in **Visual Studio 2017**.

Inside the [IDC classification GUI Classes folder](https://github.com/iotJumpway/IoT-JumpWay-Microsoft-Examples/tree/master/Intel-AI-DevJam-IDC/IDC-Classifier-GUI/Classes "IDC classification GUI Classes folder") you will find a file called [GlobalData.cs](https://github.com/iotJumpway/IoT-JumpWay-Microsoft-Examples/tree/master/Intel-AI-DevJam-IDC/IDC-Classifier-GUI/Classes "GlobalData.cs"), in here you will find settings that you can use to connect to your IDC Classifier Server. When you start your IDC Classifier Server, the output will show you the IP/FQD and port number.

```
namespace IDC_Classifier_GUI
{
    class GlobalData
    {
        public string ip = "YOUR SERVER IP";
        public int port = 8080;
        public string endpoint = "/api/TASS/infer";
        public string endpointIDC = "/api/IDC/infer";

        public int expectedCount = 6;
    }
}
```

## Testing Data

Inside the GUI project folder you will find a folder callled **Data**. Currently this folder has 12 specifically chosen unseen histology images. The images chosen were examples that I believed to be very similar to examples in the opposing class, the purpose of chosing these images was to see how the network reacts with very similar but opposite class images.

To add your own data you can remove the images in the Data folder and add your own dataset to the folder. Once you have added them to the folder you need to remove any unused images from the directory inside of Visual Studio and then add the images into the project by right clicking on the **Data** folder, clicking add, and then selecting your new dataset and adding them to the project. 

## Testing The Universal Windows Application

![Testing The Universal Windows Application](images/permissions.jpg)

For this to work it is neccessary for you to have added your photo to the [Known Data](https://github.com/iotJumpway/IoT-JumpWay-Microsoft-Examples/tree/master/Intel-AI-DevJam-IDC/IDC-Classifier/data/known "Known Data") folder of the [IDC Classifier](https://github.com/iotJumpway/IoT-JumpWay-Microsoft-Examples/tree/master/Intel-AI-DevJam-IDC/IDC-Classifier "IDC Classifier") folder. 

Run the app and as the app starts up it will ask you for camera and microphone permissions (microphone is currently unused at this stage in development). Once you accept the permissions the camera should start up and display on the screen. 

![Testing The Universal Windows Application](images/camera-screen.jpg)

There is a known bug related to this part of the application which uses code from the [Windows Universal Samples: Basic camera app sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/CameraStarterKit "Windows Universal Samples: Basic camera app sample"). You may need to restart the application a number of times before your camera loads. 

Click on the camera button on the right hand side to authenticate yourself. The application will take a photo of you and send it to the server for classification. You should now be authenticated onto the system, to add other people that have permissions to use the use the system simply add their photo to the known data folder in the IDC Classifier.

![Testing The Universal Windows Application](images/slides.jpg)

Click on the **Classify All Images** button to begin the classification process. The application will loop through the data and send it to the server for the classification. As each image is processed the application will notify you using voice, once the application finishes it will notify you of positive identifications, 

## Results

As mentioned the images were purposely chosen to challenge the network on false negatives and positives. Ideally there would be 0 of either, but the best case scenario with misclassification is false positives, as it would be better to incorrectly predict non cancerous as cancercerous than it would be to predict cancerous as non cancerous.

The application has been set up to detect if a test classification is correct by checking for a string in file name to compare against the prediction. In this applications case, it will check negative predictions to see if the string **class0** exists in the file name, and for positive predictions it will check for **class1**.

The logs of the output can be viewed in the output area of Visual Studio. Here it will display the info of each image processed, the prediction and whether it is false positive/false negative or correct/incorrect.

## Get Involved 
This project is open sourced under the MIT license. All contributions are welcome, you can choose from any of the features list below or submit your own features for review via a pull request. 

## Features List 
Below you will find any features that will be implemented. Pull requests are welcome.

- [IoTJumpWay Integration](https://www.iotjumpway.tech "IoTJumpWay Integration")

## Bugs/Issues

Please feel free to create issues for bugs and general issues you come across whilst using this or any other IoT JumpWay Microsoft repo issues: [IoT-JumpWay-Microsoft-Examples Github Issues](https://github.com/iotJumpway/IoT-JumpWay-Microsoft-Examples/issues "IoT-JumpWay-Microsoft-Examples Github Issues")

## Known Bugs
Below you will find all known bugs in the application. Each bug has a corresponding issue in the repo issues area. Pull requests are welcome.

- [KNOWN BUG: Crashes after permissions](https://github.com/iotJumpway/IoT-JumpWay-Microsoft-Examples/issues/1 "KNOWN BUG: Crashes after permissions")

## Contributors

[![Adam Milton-Barker, Intel® Software Innovator](../../images/Intel-Software-Innovator.jpg)](https://github.com/AdamMiltonBarker)

