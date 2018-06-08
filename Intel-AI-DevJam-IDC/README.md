# Intel AI DevJam Demo

![Intel® Movidius](IDC-Classifier/images/IDC-Classification.jpg)

## Introduction

The **Intel AI DevJam Demo** uses a **Windows application** to communicate with a **facial recognition classifier** and a classifier trained to detect **Invasive Ductal Carcinoma (Breast cancer)** in **histology images**. The project combines the  [Invasive Ductal Carcinoma (IDC) Classification Using Computer Vision & IoT](https://github.com/iotJumpway/IoT-JumpWay-Intel-Examples/tree/master/Intel-Movidius/IDC-Classification "Invasive Ductal Carcinoma (IDC) Classification Using Computer Vision & IoT") and [TASS Movidius Facenet Classifier](https://github.com/iotJumpway/IoT-JumpWay-Intel-Examples/tree/master/Intel-Movidius/TASS/Facenet "TASS Movidius Facenet Classifier") projects.

## Windows Universal Application

A **Windows Universal Application** allows training and querying the **IDC and facial recognition classifiers**, facial recognition training requires 1 image per person to be able to identify them. The **Windows Universal Application** also allows uploading **histology images** of **IDC** positive or negative slides for classification. 

## Linux

**Invasive Ductal Carcinoma (IDC) Classification Using Computer Vision & IoT** combines **Computer Vision** and the **Internet of Things** to provide a way to train a neural network with labelled breast cancer histology images to detect **Invasive Ductal Carcinoma (IDC)** in unseen/unlabelled images.

![Intel® Movidius](IDC-Classifier/images/Movidius.jpg)

For classification the project uses the **Intel® Movidius** and a custom trained **Facenet** to carry out **facial classification**, and a custom trained **Inception V3 model** for detecting **Invasive Ductal Carcinoma (IDC)**. IoT communication is powered by the [IoT JumpWay](https://iot.techbubbletechnologies.com "IoT JumpWay").

The **TASS Movidius Facenet Classifier** uses **Siamese Neural Networks** and **Triplet Loss** to classify known and unknown faces. The project uses an UP2 the Intel Movidius and the IoT JumpWay for IoT connectivity.

## Bugs/Issues

Please feel free to create issues for bugs and general issues you come across whilst using this or any other Intel® related IoT JumpWay issues. You may also use the issues area to ask for general help whilst using the IoT JumpWay in your IoT projects.

## Contributors

[![Adam Milton-Barker, Intel® Software Innovator](../images/Intel-Software-Innovator.jpg)](https://github.com/AdamMiltonBarker)

