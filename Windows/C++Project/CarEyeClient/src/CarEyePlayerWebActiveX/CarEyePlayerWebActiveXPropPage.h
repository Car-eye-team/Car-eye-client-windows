#pragma once

// CarEyePlayerWebActiveXPropPage.h : CCarEyePlayerWebActiveXPropPage 属性页类的声明。


// CCarEyePlayerWebActiveXPropPage : 有关实现的信息，请参阅 CarEyePlayerWebActiveXPropPage.cpp。

class CCarEyePlayerWebActiveXPropPage : public COlePropertyPage
{
	DECLARE_DYNCREATE(CCarEyePlayerWebActiveXPropPage)
	DECLARE_OLECREATE_EX(CCarEyePlayerWebActiveXPropPage)

// 构造函数
public:
	CCarEyePlayerWebActiveXPropPage();

// 对话框数据
	enum { IDD = IDD_PROPPAGE_CarEyePLAYERWEBACTIVEX };

// 实现
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 消息映射
protected:
	DECLARE_MESSAGE_MAP()
};

