﻿using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Text;

namespace GlucaTrack.Communication
{
    public interface IMeter: IDisposable
    {
        System.IO.Ports.SerialPort Port
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the meter id from the meter types table
        /// </summary>
        int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the serial number of the meter.
        /// </summary>
        string SerialNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the meter description.
        /// </summary>
        string MeterDescription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the samples available on the meter.
        /// </summary>
        int SampleCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the glucose tests.
        /// </summary>
        Records.RecordDataTable Records
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the temporary holder for data from the serial port.
        /// </summary>
        string RawData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the time it took to read the records from the device in seconds.
        /// </summary>
        double ReadTime
        {
            get;
        }
        
        /// <summary>
        /// Gets whether the underlying serial port is in an opened state.
        /// </summary>
        bool IsPortOpen
        {
            get;
        }

        #region Events
        event EventHandler ReadFinished;
        event EventHandler RecordRead;
        event EventHandler HeaderRead;
        #endregion

        /// <summary>
        /// Reads data from the meter.
        /// </summary>
        void ReadData();

        /// <summary>
        /// On data received event handler for the serial port.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DataReceived(object sender, SerialDataReceivedEventArgs e);

        /// <summary>
        /// Connects to the meter.
        /// </summary>
        /// <param name="COMport">COM port the meter communicates on.</param>
        /// <returns>If connection was successful.</returns>
        bool Connect(string COMport);

        /// <summary>
        /// Closes connection to the meter.
        /// </summary>
        /// <returns></returns>
        bool Close();

        /// <summary>
        /// Is the meter connected to the specified com port
        /// </summary>
        /// <param name="COMport">Com port to look for the meter on.</param>
        /// <returns>Boolean representing if its present or not on the specified com port.</returns>
        bool IsMeterConnected(string COMport);
    }
}
