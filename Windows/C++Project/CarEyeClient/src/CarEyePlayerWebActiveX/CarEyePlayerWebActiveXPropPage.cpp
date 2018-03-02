// CarEyePlayerWebActiveXPropPage.cpp : CCarEyePlayerWebActiveXPropPage 属性页类的实现。

#include "stdafx.h"
#include "CarEyePlayerWebActiveX.h"
#include "CarEyePlayerWebActiveXPropPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNCREATE(CCarEyePlayerWebActiveXPropPage, COlePropertyPage)



// 消息映射

BEGIN_MESSAGE_MAP(CCarEyePlayerWebActiveXPropPage, COlePropertyPage)
END_MESSAGE_MAP()



// 初始化类工厂和 guid

IMPLEMENT_OLECREATE_EX(CCarEyePlayerWebActiveXPropPage, "CarEyePLAYERWEBA.CarEyePlayerWebAPropPage.1",
	0xf594479c, 0x1a17, 0x49c7, 0xae, 0xf8, 0x86, 0x7a, 0x93, 0x2c, 0x20, 0xa2)



// CCarEyePlayerWebActiveXPropPage::CCarEyePlayerWebActiveXPropPageFactory::UpdateRegistry -
// 添加或移除 CCarEyePlayerWebActiveXPropPage 的系统注册表项

BOOL CCarEyePlayerWebActiveXPropPage::CCarEyePlayerWebActiveXPropPageFactory::UpdateRegistry(BOOL bRegister)
{
	if (bRegister)
		return AfxOleRegisterPropertyPageClass(AfxGetInstanceHandle(),
			m_clsid, IDS_CarEyePLAYERWEBACTIVEX_PPG);
	else
		return AfxOleUnregisterClass(m_clsid, NULL);
}



// CCarEyePlayerWebActiveXPropPage::CCarEyePlayerWebActiveXPropPage - 构造函数

CCarEyePlayerWebActiveXPropPage::CCarEyePlayerWebActiveXPropPage() :
	COlePropertyPage(IDD, IDS_CarEyePLAYERWEBACTIVEX_PPG_CAPTION)
{
}



// CCarEyePlayerWebActiveXPropPage::DoDataExchange - 在页和属性间移动数据

void CCarEyePlayerWebActiveXPropPage::DoDataExchange(CDataExchange* pDX)
{
	DDP_PostProcessing(pDX);
}



// CCarEyePlayerWebActiveXPropPage 消息处理程序
