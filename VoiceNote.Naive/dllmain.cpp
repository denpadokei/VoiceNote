// dllmain.cpp : DLL アプリケーションのエントリ ポイントを定義します。
#include "pch.h"

#include <windows.h>
#include <mmdeviceapi.h>
#include <endpointvolume.h>

#define DLLExport __declspec(dllexport)

extern "C"
{
    DLLExport int GetDefaultEndpoint(int dataFlow, int role, WCHAR *deviceID) {
        IMMDeviceEnumerator* pEnum = nullptr;
        auto hr = CoCreateInstance(__uuidof(MMDeviceEnumerator), NULL, CLSCTX_ALL, IID_PPV_ARGS(&pEnum));
        if (FAILED(hr))
        {
            return hr;
        }
        IMMDevice* pDevice = nullptr;
        hr = pEnum->GetDefaultAudioEndpoint((EDataFlow)dataFlow, (ERole)role, &pDevice);
        LPWSTR deviceIDArray = nullptr;
        pDevice->GetId(&deviceIDArray);
        ::lstrcpy(deviceID, deviceIDArray);
        return hr;
    }
}