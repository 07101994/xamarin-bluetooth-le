using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Plugin.BLE.Abstractions.Exceptions;

namespace Plugin.BLE.Abstractions.Contracts
{
    public interface IAdapter
    {
        // events
        event EventHandler<DeviceDiscoveredEventArgs> DeviceAdvertised;
        event EventHandler<DeviceDiscoveredEventArgs> DeviceDiscovered;
        event EventHandler<DeviceConnectionEventArgs> DeviceConnected;
        event EventHandler<DeviceConnectionEventArgs> DeviceDisconnected;
        event EventHandler<DeviceConnectionEventArgs> DeviceConnectionLost;
        event EventHandler ScanTimeoutElapsed;

        bool IsScanning { get; }

        /// <summary>
        /// Timeout for Ble scanning. Default is 10000.
        /// </summary>
        int ScanTimeout { get; set; }
        //IList<IDevice> DiscoveredDevices { get; }
        IList<IDevice> ConnectedDevices { get; }

        /// <summary>
        /// Starts scanning for BLE devices.
        /// </summary>
        /// <returns></returns>
        Task StartScanningForDevicesAsync();
        Task StartScanningForDevicesAsync(CancellationToken cancellationToken);
        Task StartScanningForDevicesAsync(Guid[] serviceUuids);
        Task StartScanningForDevicesAsync(Guid[] serviceUuids, CancellationToken cancellationToken);
        Task StopScanningForDevicesAsync();

        Task ConnectToDeviceAync(IDevice device, bool autoconnect = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="autoconnect"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="DeviceConnectionException">Thrown if the device c�nnection fails.</exception>
        Task ConnectToDeviceAync(IDevice device, bool autoconnect, CancellationToken cancellationToken);
        Task DisconnectDeviceAsync(IDevice device);
    }
}

