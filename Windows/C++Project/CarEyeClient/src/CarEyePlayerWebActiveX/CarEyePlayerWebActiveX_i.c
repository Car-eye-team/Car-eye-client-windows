

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0555 */
/* at Fri Mar 02 11:11:53 2018
 */
/* Compiler settings for CarEyePlayerWebActiveX.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 7.00.0555 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


#ifdef __cplusplus
extern "C"{
#endif 


#include <rpc.h>
#include <rpcndr.h>

#ifdef _MIDL_USE_GUIDDEF_

#ifndef INITGUID
#define INITGUID
#include <guiddef.h>
#undef INITGUID
#else
#include <guiddef.h>
#endif

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        DEFINE_GUID(name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8)

#else // !_MIDL_USE_GUIDDEF_

#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        const type name = {l,w1,w2,{b1,b2,b3,b4,b5,b6,b7,b8}}

#endif !_MIDL_USE_GUIDDEF_

MIDL_DEFINE_GUID(IID, LIBID_CarEyePlayerWebActiveXLib,0xE7319905,0x7F58,0x422D,0x9A,0xF6,0x29,0x20,0x78,0xB8,0x5D,0x1C);


MIDL_DEFINE_GUID(IID, DIID__DCarEyePlayerWebActiveX,0xFB5E35A6,0x2538,0x47C4,0x9B,0x40,0xB0,0xFB,0x6A,0x00,0xDE,0xA0);


MIDL_DEFINE_GUID(IID, DIID__DCarEyePlayerWebActiveXEvents,0x66887A6D,0xC75B,0x48B8,0xB5,0xE1,0xBD,0x72,0x2D,0x87,0x59,0x23);


MIDL_DEFINE_GUID(CLSID, CLSID_CarEyePlayerWebActiveX,0x1EE1C648,0xF4A9,0x42F9,0x9A,0xA7,0x2C,0x8E,0x3A,0xF7,0xB7,0xFD);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



