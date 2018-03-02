
#include "StdAfx.h"
#include "CarEyePlayerManager.h"

CarEyePlayerManager::CarEyePlayerManager(void)
{
	memset(&m_sSourceInfo, 0x0, sizeof(CarEye_LOCAL_SOURCE_T));
	m_sSourceInfo.rtspSourceId = -1;

}

CarEyePlayerManager::~CarEyePlayerManager(void)
{
}

	//Start  --  如果传入的是宽串，可以参考下面这段
// 	wchar_t wszURL[128] = {0,};
// 	if (NULL != pEdtServerAddr)	pEdtServerAddr->GetWindowTextW(wszURL, sizeof(wszURL));
// 	if (wcslen(wszURL) < 1)		return;
// 
// 	char szURL[128] = {0,};
// 	__WCharToMByte(wszURL, szURL, sizeof(szURL)/sizeof(szURL[0]));
// 	
int CarEyePlayerManager::Start(char* szURL, HWND hShowWnd, 
	RENDER_FORMAT eRenderFormat, int rtpovertcp, const char *username, const char *password, int bHardDecode, MediaSourceCallBack callback, void *userPtr) 
{
	//Stop
	if (m_sSourceInfo.rtspSourceId > 0)
	{
		Close();
		return -1;
	}

	m_sSourceInfo.rtspSourceId = CarEyePlayer_OpenStream(szURL, hShowWnd, eRenderFormat, 
		rtpovertcp, username, password, callback, userPtr, (bHardDecode==TRUE)?true:false );
	return	m_sSourceInfo.rtspSourceId ;
}
 
void CarEyePlayerManager::Config(int nFrameCache,  BOOL bPlaySound, BOOL bShowToScale, BOOL  bShowStatisticInfo )
{
	if (m_sSourceInfo.rtspSourceId > 0)
	{
		CarEyePlayer_SetFrameCache(m_sSourceInfo.rtspSourceId, nFrameCache);		//设置缓存
		CarEyePlayer_ShowStatisticalInfo(m_sSourceInfo.rtspSourceId, bShowStatisticInfo);
		//按比例显示
		CarEyePlayer_SetShownToScale(m_sSourceInfo.rtspSourceId, bShowToScale );
		if (bPlaySound)
		{
			CarEyePlayer_PlaySound(m_sSourceInfo.rtspSourceId);
		}
	}
}

void	CarEyePlayerManager::Close()
{
	if (m_sSourceInfo.rtspSourceId > 0)
	{
		CarEyePlayer_CloseStream(m_sSourceInfo.rtspSourceId);
		m_sSourceInfo.rtspSourceId = -1;
	}
}

int CarEyePlayerManager::InRunning()
{
	return m_sSourceInfo.rtspSourceId;
}

void CarEyePlayerManager::SetOSD(int show, CAREYE_PALYER_OSD osd)
{
	CarEyePlayer_ShowOSD(m_sSourceInfo.rtspSourceId, show,  osd);
}
