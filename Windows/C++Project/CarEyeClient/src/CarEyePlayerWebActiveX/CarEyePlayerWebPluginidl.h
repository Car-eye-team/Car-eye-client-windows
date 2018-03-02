

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


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


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__


#ifndef __CarEyePlayerWebPluginidl_h__
#define __CarEyePlayerWebPluginidl_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef ___DCarEyePlayerWebActiveX_FWD_DEFINED__
#define ___DCarEyePlayerWebActiveX_FWD_DEFINED__
typedef interface _DCarEyePlayerWebActiveX _DCarEyePlayerWebActiveX;
#endif 	/* ___DCarEyePlayerWebActiveX_FWD_DEFINED__ */


#ifndef ___DCarEyePlayerWebActiveXEvents_FWD_DEFINED__
#define ___DCarEyePlayerWebActiveXEvents_FWD_DEFINED__
typedef interface _DCarEyePlayerWebActiveXEvents _DCarEyePlayerWebActiveXEvents;
#endif 	/* ___DCarEyePlayerWebActiveXEvents_FWD_DEFINED__ */


#ifndef __CarEyePlayerWebActiveX_FWD_DEFINED__
#define __CarEyePlayerWebActiveX_FWD_DEFINED__

#ifdef __cplusplus
typedef class CarEyePlayerWebActiveX CarEyePlayerWebActiveX;
#else
typedef struct CarEyePlayerWebActiveX CarEyePlayerWebActiveX;
#endif /* __cplusplus */

#endif 	/* __CarEyePlayerWebActiveX_FWD_DEFINED__ */


#ifdef __cplusplus
extern "C"{
#endif 



#ifndef __CarEyePlayerWebActiveXLib_LIBRARY_DEFINED__
#define __CarEyePlayerWebActiveXLib_LIBRARY_DEFINED__

/* library CarEyePlayerWebActiveXLib */
/* [control][version][uuid] */ 


EXTERN_C const IID LIBID_CarEyePlayerWebActiveXLib;

#ifndef ___DCarEyePlayerWebActiveX_DISPINTERFACE_DEFINED__
#define ___DCarEyePlayerWebActiveX_DISPINTERFACE_DEFINED__

/* dispinterface _DCarEyePlayerWebActiveX */
/* [uuid] */ 


EXTERN_C const IID DIID__DCarEyePlayerWebActiveX;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("FB5E35A6-2538-47C4-9B40-B0FB6A00DEA0")
    _DCarEyePlayerWebActiveX : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DCarEyePlayerWebActiveXVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DCarEyePlayerWebActiveX * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DCarEyePlayerWebActiveX * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DCarEyePlayerWebActiveX * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DCarEyePlayerWebActiveX * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DCarEyePlayerWebActiveX * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DCarEyePlayerWebActiveX * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DCarEyePlayerWebActiveX * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DCarEyePlayerWebActiveXVtbl;

    interface _DCarEyePlayerWebActiveX
    {
        CONST_VTBL struct _DCarEyePlayerWebActiveXVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DCarEyePlayerWebActiveX_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DCarEyePlayerWebActiveX_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DCarEyePlayerWebActiveX_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DCarEyePlayerWebActiveX_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DCarEyePlayerWebActiveX_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DCarEyePlayerWebActiveX_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DCarEyePlayerWebActiveX_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DCarEyePlayerWebActiveX_DISPINTERFACE_DEFINED__ */


#ifndef ___DCarEyePlayerWebActiveXEvents_DISPINTERFACE_DEFINED__
#define ___DCarEyePlayerWebActiveXEvents_DISPINTERFACE_DEFINED__

/* dispinterface _DCarEyePlayerWebActiveXEvents */
/* [uuid] */ 


EXTERN_C const IID DIID__DCarEyePlayerWebActiveXEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("66887A6D-C75B-48B8-B5E1-BD722D875923")
    _DCarEyePlayerWebActiveXEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _DCarEyePlayerWebActiveXEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _DCarEyePlayerWebActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            __RPC__deref_out  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _DCarEyePlayerWebActiveXEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _DCarEyePlayerWebActiveXEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _DCarEyePlayerWebActiveXEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _DCarEyePlayerWebActiveXEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _DCarEyePlayerWebActiveXEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _DCarEyePlayerWebActiveXEvents * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS *pDispParams,
            /* [out] */ VARIANT *pVarResult,
            /* [out] */ EXCEPINFO *pExcepInfo,
            /* [out] */ UINT *puArgErr);
        
        END_INTERFACE
    } _DCarEyePlayerWebActiveXEventsVtbl;

    interface _DCarEyePlayerWebActiveXEvents
    {
        CONST_VTBL struct _DCarEyePlayerWebActiveXEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _DCarEyePlayerWebActiveXEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _DCarEyePlayerWebActiveXEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _DCarEyePlayerWebActiveXEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _DCarEyePlayerWebActiveXEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _DCarEyePlayerWebActiveXEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _DCarEyePlayerWebActiveXEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _DCarEyePlayerWebActiveXEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___DCarEyePlayerWebActiveXEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_CarEyePlayerWebActiveX;

#ifdef __cplusplus

class DECLSPEC_UUID("1EE1C648-F4A9-42F9-9AA7-2C8E3AF7B7FD")
CarEyePlayerWebActiveX;
#endif
#endif /* __CarEyePlayerWebActiveXLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


