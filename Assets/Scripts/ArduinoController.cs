using System.IO.Ports;
using UnityEngine;

public class ArduinoController : MonoBehaviour
{
    SerialPort serialPort;

    void Start()
    {
        // Set up the serial port
        serialPort = new SerialPort("COM6", 9600);
        serialPort.Open();   
    }

   /*void Update()
    {
        // Send data to the Arduino when the input is received
        if(Input.GetKey(KeyCode.Space))
        {
            serialPort.Write("1"); // Send "1" to the serial port
        }
    }*/

    void OnApplicationQuit()
    {
        // Close the serial port when the application quits
        serialPort.Close();
    }

    public void SendMessage1()
    {
        //serialPort.Open();
        serialPort.Write("1");
        Debug.Log("message send");
    }

    public void SendMessage2()
    {
        serialPort.Write("2");
    }

    public void SendMessage3()
    {
        serialPort.Write("3");
    }
    public void SendMessage4()
    {
        serialPort.Write("4");
    }
}
