/*
   (C) Copyright 1999-2009 by Autodesk, Inc. 
  
   Permission to use, copy, modify, and distribute this software in
   object code form for any purpose and without fee is hereby granted, 
   provided that the above copyright notice appears in all copies and 
   that both that copyright notice and the limited warranty and
   restricted rights notice below appear in all supporting 
   documentation.
  
   AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
   AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
   MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC. 
   DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
   UNINTERRUPTED OR ERROR FREE.
  
   Use, duplication, or disclosure by the U.S. Government is subject to 
   restrictions set forth in FAR 52.227-19 (Commercial Computer
   Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
   (Rights in Technical Data and Computer Software), as applicable.
  
  
*/


/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


 /* File created by MIDL compiler version 7.00.0500 */
/* at Sun Feb 08 22:49:29 2009
 */
/* Compiler settings for U:\develop\global\src\coreacad\TYPELIB\idlsource\axauto.idl:
    Oicf, W1, Zp8, env=Win64 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

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

MIDL_DEFINE_GUID(IID, LIBID_AXDBLib,0xFFC2A8DB,0xA497,0x4087,0x94,0x1C,0xC5,0xB5,0x46,0x22,0x37,0xEA);


MIDL_DEFINE_GUID(IID, IID_IAcadObject,0x425F38BA,0x456A,0x4937,0x88,0x25,0xBE,0xA0,0x6D,0x12,0xDA,0xA2);


MIDL_DEFINE_GUID(IID, IID_IAcadDictionary,0xD5551E84,0xC9C8,0x4939,0x81,0x7B,0x63,0xDD,0x7C,0xE8,0x0C,0xAF);


MIDL_DEFINE_GUID(IID, IID_IAcadEntity,0x3F403358,0x8F13,0x495C,0x8B,0xFF,0x12,0x32,0x8A,0x1F,0x38,0x23);


MIDL_DEFINE_GUID(IID, IID_IAcadBlock,0xD22E36B7,0xAD82,0x4F43,0xA6,0x0D,0x58,0x24,0xFD,0x84,0x2E,0x9F);


MIDL_DEFINE_GUID(IID, IID_IAcadDatabase,0x1086243D,0x9230,0x49F6,0xB7,0xDE,0xFF,0x08,0x2A,0x68,0x3F,0x50);


MIDL_DEFINE_GUID(IID, IID_IAcadSectionTypeSettings,0xB3B0361E,0x6D90,0x4C66,0xAD,0x49,0xBA,0x59,0x7F,0xAA,0x24,0xB3);


MIDL_DEFINE_GUID(IID, IID_IAcadSectionTypeSettings2,0x0FD65FD0,0xF266,0x46D9,0xA3,0x7D,0xB9,0x76,0x33,0xE9,0x85,0xF1);


MIDL_DEFINE_GUID(IID, IID_IAcadHyperlink,0x84C08E60,0xF267,0x4C3B,0x86,0x7D,0xD3,0x5A,0x3D,0xED,0x92,0xCE);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadHyperlink,0xCD9526F0,0xF312,0x48BC,0x97,0xC0,0x76,0x37,0xA3,0x2C,0xF6,0x3E);


MIDL_DEFINE_GUID(IID, IID_IAcadDynamicBlockReferenceProperty,0x8B49D14E,0x9F7E,0x42C5,0xB3,0xC5,0xFF,0x8F,0x88,0x52,0xCF,0x56);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDynamicBlockReferenceProperty,0x6658F584,0x15CB,0x4A36,0xBE,0xEE,0xF2,0x5C,0x60,0x6F,0xC4,0x45);


MIDL_DEFINE_GUID(IID, IID_IAcadAcCmColor,0x027DD570,0x25AD,0x41D9,0x87,0x58,0x1D,0xD5,0xFB,0xB3,0x6A,0x13);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadAcCmColor,0x2D909319,0x0322,0x4EE7,0xB5,0x3E,0xEF,0x48,0xD3,0xB1,0x83,0x3E);


MIDL_DEFINE_GUID(IID, IID_IAcadObjectEvents,0x1F7BF7B4,0xBCC8,0x4670,0x84,0x0E,0x60,0x3F,0x58,0x52,0x57,0xE9);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadObject,0x5832D854,0xC5A5,0x4A63,0x8D,0xCE,0xB1,0x50,0xBB,0xF7,0x18,0x34);


MIDL_DEFINE_GUID(IID, IID_IAcadXRecord,0x4E82F823,0x9F02,0x4EA9,0xA9,0x9B,0xDD,0xAC,0x18,0x18,0x7F,0x0E);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadXRecord,0x310DEC40,0xB5A5,0x4CA7,0xA1,0x41,0xD6,0x36,0x93,0x0A,0x72,0xDC);


MIDL_DEFINE_GUID(IID, IID_IAcadSortentsTable,0xF740BA86,0xEAF8,0x4EE3,0x8F,0xCF,0x28,0xB6,0x35,0x63,0xA8,0xC3);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSortentsTable,0xA89FFC20,0xCAE1,0x4FFF,0x96,0xA4,0x24,0x22,0xB3,0x05,0xB5,0x7B);


MIDL_DEFINE_GUID(IID, IID_IAcadDimStyle,0xAAF15482,0x7287,0x4766,0xA3,0x33,0xB2,0x34,0x58,0xDC,0xC6,0x5A);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimStyle,0x28078C83,0x8E39,0x4840,0x9D,0x8C,0x96,0x99,0x38,0xED,0x2C,0xD6);


MIDL_DEFINE_GUID(IID, IID_IAcadLayer,0xEF7F5376,0x1943,0x4235,0x90,0x53,0x32,0xBA,0xEA,0xCC,0xCB,0x49);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLayer,0x616686F6,0xF1A8,0x45C1,0x8F,0x2E,0x95,0xD1,0x56,0xA7,0xC6,0xD0);


MIDL_DEFINE_GUID(IID, IID_IAcadLineType,0xCC498941,0xDF18,0x40D6,0xA0,0x59,0x9B,0x4B,0xCF,0x55,0x6F,0xAE);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLineType,0x46ECCA31,0x075F,0x4252,0x86,0x90,0xF9,0x87,0xEA,0xA8,0x3A,0x75);


MIDL_DEFINE_GUID(IID, IID_IAcadMaterial,0x00EBEC55,0xC445,0x4AED,0xA8,0x18,0xEF,0xE7,0xCB,0x75,0x22,0x13);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadMaterial,0x79D75C1D,0x5BB5,0x4A6E,0x85,0x53,0x60,0xF1,0x83,0x93,0xE0,0xC7);


MIDL_DEFINE_GUID(IID, IID_IAcadRegisteredApplication,0xE428059C,0x69D4,0x4978,0x92,0xCF,0x67,0x0B,0xB5,0x15,0xB7,0xBF);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadRegisteredApplication,0xC6809E20,0x46BF,0x4934,0x87,0x62,0xF8,0x80,0x7C,0x57,0x88,0xFF);


MIDL_DEFINE_GUID(IID, IID_IAcadTextStyle,0xC62D0CA8,0xC3C5,0x42DF,0xAF,0xB9,0x3C,0x43,0x9A,0x0E,0xF4,0xCB);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadTextStyle,0x9EEC21FD,0x3161,0x49ED,0x87,0x68,0x34,0x76,0x5D,0xAD,0x77,0x5F);


MIDL_DEFINE_GUID(IID, IID_IAcadUCS,0x81538710,0xAE65,0x441C,0xAB,0x55,0x73,0xAF,0x68,0x18,0xAE,0xEB);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadUCS,0x9F42DFA2,0xF628,0x45E7,0x90,0x93,0x5A,0x93,0x70,0x21,0x5B,0x4E);


MIDL_DEFINE_GUID(IID, IID_IAcadView,0x942FFF4B,0xFCFF,0x4BDB,0xAE,0xE1,0xBC,0x2B,0xB1,0x6C,0x9E,0x14);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadView,0x8EB8EA30,0x71B6,0x486F,0x85,0x13,0x21,0xF4,0xA0,0xF5,0x5E,0xE8);


MIDL_DEFINE_GUID(IID, IID_IAcadViewport,0x841E1C09,0x27EE,0x47A9,0xA8,0x64,0xEF,0x11,0x45,0xDE,0x58,0x49);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadViewport,0x2D68B2C0,0xAAAD,0x4547,0x94,0x55,0x7F,0x47,0xBA,0x2F,0xBE,0x90);


MIDL_DEFINE_GUID(IID, IID_IAcadGroup,0x30A5C0D7,0x0157,0x40E0,0x8A,0x25,0x1B,0x17,0xCE,0x14,0xF7,0xEC);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadGroup,0x98BC2557,0x3596,0x4E80,0x8A,0x77,0xDA,0x5E,0xE6,0xE1,0x3D,0x05);


MIDL_DEFINE_GUID(IID, IID_IAcadPlotConfiguration,0xC0FFEC74,0xADD8,0x46C7,0xA6,0xD6,0xE2,0xB1,0xD3,0xFA,0x12,0xAC);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPlotConfiguration,0xEF5B641C,0xFC36,0x4936,0xBB,0x03,0x9D,0x48,0x09,0xBA,0xA4,0x5B);


MIDL_DEFINE_GUID(IID, IID_IAcadLayout,0xC6F55F5A,0x33AF,0x4B5F,0x99,0x49,0x86,0xC6,0xAE,0xEF,0x18,0x34);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLayout,0x28E5B54D,0xD4DE,0x4BD6,0x87,0xDC,0xB7,0x95,0xBD,0xF9,0xF0,0xB2);


MIDL_DEFINE_GUID(IID, IID_IAcadIdPair,0x557263C6,0x4FB1,0x4576,0xAE,0x87,0x25,0xDC,0x9F,0x6C,0x45,0xE7);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadIdPair,0x8997D4FE,0x827F,0x46E9,0xB0,0x78,0x00,0xA8,0x96,0x97,0x94,0x00);


MIDL_DEFINE_GUID(IID, IID_IAcadTableStyle,0xF3506556,0x7B84,0x4D4A,0xAE,0xB9,0x5F,0xA4,0xA5,0x26,0x8C,0x56);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadTableStyle,0xF4C9A261,0xDD69,0x45E5,0xBA,0x9C,0xB7,0x0B,0xD8,0xB9,0xE7,0x70);


MIDL_DEFINE_GUID(IID, IID_IAcadSectionSettings,0x7D35B280,0x745B,0x419B,0x84,0x5F,0x24,0x4F,0x6C,0x78,0x4D,0x77);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSectionSettings,0x3818E0CC,0xF69C,0x4FE6,0x9A,0xEA,0x15,0x29,0xE6,0x81,0xF3,0x57);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSectionTypeSettings,0x9AAC1B61,0x6489,0x4646,0x9D,0xEA,0xAF,0x5B,0xA2,0x3E,0xC2,0x96);


MIDL_DEFINE_GUID(IID, IID_IAcadMLeaderStyle,0x367A1F18,0x25AE,0x4CDE,0xBB,0x13,0x4A,0xDA,0x1E,0xDA,0x06,0x6A);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadMLeaderStyle,0x99211C95,0x3862,0x4E7C,0x87,0x70,0x35,0xC6,0x8C,0xA1,0x94,0x4B);


MIDL_DEFINE_GUID(IID, IID_IAcadHyperlinks,0xAD0379AD,0x1D0F,0x43A8,0x8B,0xF7,0xCA,0x8E,0x73,0xED,0x39,0x43);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadHyperlinks,0xD929AFA9,0xA6A0,0x474B,0x9F,0x26,0xF1,0x63,0x58,0xFA,0x30,0xB5);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDictionary,0x3CC77F29,0x1CFD,0x4754,0x84,0x08,0xF3,0xE9,0x47,0x39,0x12,0x38);


MIDL_DEFINE_GUID(IID, IID_IAcadLayers,0x66E080D9,0xAD12,0x4280,0xB5,0xA7,0x2E,0xBF,0xA8,0x9D,0xCA,0xE6);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLayers,0xB95A3E6E,0x5D0A,0x4080,0xA3,0x53,0x23,0xF8,0x6C,0x4A,0xDE,0xC8);


MIDL_DEFINE_GUID(IID, IID_IAcadDimStyles,0x0C284A1C,0xEAF2,0x425A,0x8D,0x21,0xA1,0xB8,0x17,0x3D,0xE1,0x96);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimStyles,0x41A5BBED,0x65C9,0x4E4A,0xAB,0xFF,0xB5,0x01,0x83,0xFE,0x49,0x2E);


MIDL_DEFINE_GUID(IID, IID_IAcadDictionaries,0x2FD39045,0xF33A,0x4FE0,0xAB,0xE0,0xEA,0x3C,0x63,0x88,0x67,0xF5);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDictionaries,0x93665D2F,0xB163,0x4168,0x97,0x4D,0x1B,0xE7,0xD7,0x25,0xCA,0x6A);


MIDL_DEFINE_GUID(IID, IID_IAcadLineTypes,0x81758580,0x5621,0x4985,0x9A,0x84,0xA6,0xA4,0xA5,0xE7,0xAD,0x94);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLineTypes,0x86BFEA05,0xD473,0x4882,0x86,0x1B,0x2E,0x71,0xE3,0x00,0x4D,0xA5);


MIDL_DEFINE_GUID(IID, IID_IAcadMaterials,0x4ED31F1B,0x468B,0x4D1B,0x9A,0xAA,0xF5,0x2E,0xD5,0x57,0x52,0xD5);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadMaterials,0xB54A1EB0,0x28A6,0x43AE,0xA4,0x5B,0xBE,0x3D,0xFB,0x94,0xE9,0x1B);


MIDL_DEFINE_GUID(IID, IID_IAcadTextStyles,0xEA00BFB5,0x4299,0x45FC,0x9A,0xBB,0x8A,0x56,0xE7,0x37,0x79,0xEB);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadTextStyles,0xDDDFA318,0x7B86,0x4721,0x85,0x72,0x65,0x9B,0x0D,0x32,0xC3,0x14);


MIDL_DEFINE_GUID(IID, IID_IAcadUCSs,0x60C5E080,0x2F24,0x40B4,0x88,0xF4,0x21,0xB7,0x55,0xA5,0xC1,0x8D);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadUCSs,0x1D20EF5D,0x1DE2,0x4167,0x9E,0x12,0xCE,0xB6,0x7E,0xB8,0x72,0x37);


MIDL_DEFINE_GUID(IID, IID_IAcadRegisteredApplications,0x5E9A1BA0,0x23FE,0x4F32,0xB8,0x02,0xEB,0xAA,0xDC,0xF9,0x04,0x56);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadRegisteredApplications,0xA86E1440,0x9D1C,0x4323,0x9A,0x34,0xC3,0x68,0x6C,0x08,0x9A,0x7D);


MIDL_DEFINE_GUID(IID, IID_IAcadViews,0xD2FC4A6D,0x894A,0x4E3E,0xAC,0xFC,0x03,0xFE,0x88,0x5A,0xC5,0xE3);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadViews,0x2150A7ED,0xDEFA,0x466B,0x9F,0x25,0xD0,0x40,0xC2,0xE7,0xC3,0x02);


MIDL_DEFINE_GUID(IID, IID_IAcadViewports,0xE09BAB22,0xA8AC,0x4B99,0x9E,0x1F,0xED,0x15,0x41,0xC4,0x73,0x30);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadViewports,0x1090BFA8,0xCBD9,0x452D,0xA9,0x67,0xF8,0x18,0x8C,0xD1,0x3D,0xDD);


MIDL_DEFINE_GUID(IID, IID_IAcadGroups,0x830A1360,0xDD64,0x4E1A,0x9C,0x06,0xB5,0x3B,0xE6,0x8B,0xD0,0x5F);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadGroups,0x58306840,0x84F5,0x4A3D,0xA0,0x35,0x43,0xCC,0x98,0x6C,0xA5,0x03);


MIDL_DEFINE_GUID(IID, IID_IAcadBlocks,0xF73108C0,0x27EE,0x4CF7,0xB9,0x09,0xB3,0x03,0x53,0x2A,0x06,0x01);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadBlocks,0x25FFDEB2,0xC0A1,0x4878,0xB8,0x10,0x2E,0x0F,0xA6,0xA6,0x92,0xAF);


MIDL_DEFINE_GUID(IID, IID_IAcadLayouts,0x88CA3904,0xBB3B,0x49A7,0x8F,0xB2,0x1E,0x45,0xA3,0x75,0x41,0xA1);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLayouts,0x173F2729,0xA2E4,0x4D7A,0xA2,0x87,0x4B,0x80,0xC8,0x19,0xDE,0x32);


MIDL_DEFINE_GUID(IID, IID_IAcadPlotConfigurations,0x67468E51,0xE585,0x4EA1,0x92,0xC4,0x45,0xCA,0x9F,0x4C,0x89,0x19);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPlotConfigurations,0x004988DE,0x88AF,0x49B7,0xBC,0x3B,0x68,0xC4,0xA4,0x29,0x71,0x07);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadEntity,0x9C4F54DC,0x58D1,0x4914,0x91,0x7D,0xDD,0xC4,0xFB,0x1A,0xBA,0x23);


MIDL_DEFINE_GUID(IID, IID_IAcadShadowDisplay,0xB323B6EE,0xF5BB,0x42A6,0xB4,0x74,0x63,0x49,0xD3,0x8B,0x4F,0xCC);


MIDL_DEFINE_GUID(IID, IID_IAcadRasterImage,0xB82704FD,0x2E41,0x48FF,0x85,0x23,0x58,0x88,0xB4,0x6B,0x1D,0x26);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadRasterImage,0x9713E314,0xF9EA,0x44E4,0xB9,0xB7,0x7D,0x6D,0x53,0xB1,0xB4,0xE5);


MIDL_DEFINE_GUID(IID, IID_IAcad3DFace,0xA85DDF97,0x91EA,0x4296,0xAD,0x6B,0xE4,0x4D,0xF6,0xFE,0x9B,0x54);


MIDL_DEFINE_GUID(CLSID, CLSID_Acad3DFace,0x5D80AEC3,0x8C87,0x4208,0x9D,0x24,0x9E,0x11,0xD6,0x15,0x1C,0xF7);


MIDL_DEFINE_GUID(IID, IID_IAcad3DPolyline,0xDF9905A8,0xE36A,0x40DA,0xB8,0xAB,0x44,0x66,0xB1,0x42,0xF2,0x5F);


MIDL_DEFINE_GUID(CLSID, CLSID_Acad3DPolyline,0x5DA978E5,0x9271,0x45A7,0x96,0x09,0x65,0xCE,0x83,0x01,0x68,0xF3);


MIDL_DEFINE_GUID(IID, IID_IAcadRegion,0x11FD0EAC,0x54FA,0x4F61,0x91,0xA7,0x8A,0xB2,0xEE,0x90,0x20,0x37);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadRegion,0x6676E009,0x9BA1,0x485C,0x98,0xD6,0x8F,0x1F,0xFA,0x59,0xBB,0x4F);


MIDL_DEFINE_GUID(IID, IID_IAcad3DSolid,0xE95E1FD4,0x24A7,0x4ABD,0xA8,0xDF,0xBF,0x13,0xF2,0xBE,0xA2,0xCD);


MIDL_DEFINE_GUID(CLSID, CLSID_Acad3DSolid,0xB9D02C87,0x012B,0x4404,0xB9,0xE5,0x6D,0xD9,0xC9,0xBB,0x8C,0xC9);


MIDL_DEFINE_GUID(IID, IID_IAcadArc,0x799D2A2A,0xD907,0x4CC8,0xAA,0xA0,0x26,0x24,0x25,0x88,0x3D,0x71);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadArc,0x5E829420,0xD163,0x4B2D,0x9E,0xBF,0xAA,0xC4,0x70,0xB6,0xD7,0x37);


MIDL_DEFINE_GUID(IID, IID_IAcadAttribute,0x0C3831A4,0xF455,0x49A9,0x8D,0x03,0x62,0xEB,0x0B,0x07,0x47,0x4C);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadAttribute,0x476B42EA,0xEF37,0x403D,0x9B,0xB2,0xDF,0xB9,0x9E,0x82,0x32,0x8B);


MIDL_DEFINE_GUID(IID, IID_IAcadAttributeReference,0x1E834238,0x18C4,0x4D0A,0xBE,0x02,0xD7,0xAE,0xFF,0x94,0xA6,0x09);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadAttributeReference,0xE1A7F239,0x4B51,0x41A9,0xA3,0xEA,0x6A,0x0B,0x80,0xF7,0x11,0x68);


MIDL_DEFINE_GUID(IID, IID_IAcadBlockReference,0x6D162051,0x7D3B,0x43E4,0x99,0x55,0x99,0xE7,0x80,0xDD,0x26,0x07);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadBlockReference,0xE8E5BF1D,0x2DB6,0x473A,0x8E,0x1A,0x4A,0xF8,0xCC,0x07,0x30,0x4D);


MIDL_DEFINE_GUID(IID, IID_IAcadCircle,0x4E50E531,0x0B12,0x46E4,0xA2,0x26,0x57,0x96,0x6D,0xB5,0xD0,0x05);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadCircle,0x8229FCDA,0x0225,0x4EF2,0x96,0x0E,0xA9,0x3B,0xCF,0x52,0x1A,0x2B);


MIDL_DEFINE_GUID(IID, IID_IAcadEllipse,0x8485202E,0x57E3,0x44B1,0x96,0x15,0x2A,0xB2,0x24,0xD3,0x95,0xB8);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadEllipse,0x1A0F769C,0x84D7,0x4AD6,0x87,0xE7,0xBA,0x15,0x0B,0x81,0x2A,0x75);


MIDL_DEFINE_GUID(IID, IID_IAcadHatch,0x0CB3D5D2,0xCBB4,0x4A3E,0xB5,0x72,0x80,0x81,0x54,0xFC,0x9B,0xAE);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadHatch,0x07BD7878,0x35B2,0x4F1F,0xA0,0xAF,0x84,0xF1,0x02,0xCE,0x86,0x74);


MIDL_DEFINE_GUID(IID, IID_IAcadLeader,0x11D050D2,0x848B,0x4EC8,0x99,0x3F,0x2C,0xE0,0x89,0x66,0x7D,0x7C);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLeader,0xB6DE099E,0x8978,0x4064,0xB8,0x56,0xBA,0x00,0x24,0xE2,0xC3,0x1C);


MIDL_DEFINE_GUID(IID, IID_IAcadSubEntity,0x49376534,0xDD5B,0x4FD1,0xB3,0x10,0x32,0xED,0x74,0x8D,0x11,0x98);


MIDL_DEFINE_GUID(IID, IID_IAcadMLeaderLeader,0x641D3F97,0x6437,0x4f2a,0x82,0xFC,0x2A,0xD7,0x3D,0x95,0x54,0xE0);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadMLeaderLeader,0xA1FB6193,0x64C2,0x4008,0xAC,0x55,0xA2,0xAD,0x97,0xFD,0x38,0xF8);


MIDL_DEFINE_GUID(IID, IID_IAcadMLeader,0x5D8A52A9,0x9205,0x4BE0,0xA2,0xF1,0x43,0x16,0x12,0xFB,0xB3,0x5D);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadMLeader,0x84BC656B,0x4F6C,0x4364,0xAE,0xCD,0x2F,0xBB,0xCD,0x0B,0x97,0xDF);


MIDL_DEFINE_GUID(IID, IID_IAcadLWPolyline,0x134E226C,0x5024,0x4EFC,0xBB,0x7D,0x13,0x1C,0xD7,0x5A,0xF0,0xC9);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLWPolyline,0x3C66A2DE,0xEBCF,0x48CF,0x8B,0x0E,0x75,0x59,0x5F,0x40,0xEB,0x24);


MIDL_DEFINE_GUID(IID, IID_IAcadLine,0xDF524ECB,0xD59E,0x464B,0x89,0xB6,0xD3,0x28,0x22,0x28,0x27,0x78);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLine,0x7C34C0FB,0x6848,0x4FF8,0x97,0x5A,0x19,0xA2,0x7F,0xBA,0xD1,0xB4);


MIDL_DEFINE_GUID(IID, IID_IAcadMText,0x8830DA6E,0x58B1,0x45D2,0x97,0x1E,0xB4,0xBE,0x04,0x6C,0x0F,0x75);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadMText,0xB992851C,0x8FFD,0x4C8A,0x81,0xF2,0xB4,0x10,0x36,0x99,0x70,0xAA);


MIDL_DEFINE_GUID(IID, IID_IAcadPoint,0x6AD09D7A,0xA925,0x45D9,0x99,0xD1,0x6E,0x0E,0x25,0x30,0x17,0x34);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPoint,0xCB758EB0,0x0090,0x4DF9,0xA5,0x6C,0x0F,0xA5,0xEF,0x5C,0xDB,0xC6);


MIDL_DEFINE_GUID(IID, IID_IAcadPolyline,0xD5E5DEA6,0xB3A5,0x4FD7,0xA5,0x07,0x5A,0x7F,0x18,0xBE,0xBD,0x10);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPolyline,0xE8B54D88,0xEE03,0x4C0F,0x85,0x8D,0x87,0x90,0x24,0xBB,0x88,0x11);


MIDL_DEFINE_GUID(IID, IID_IAcadPolygonMesh,0xFD58EA44,0x8301,0x48B1,0x8E,0xCE,0xBD,0x01,0xD9,0x03,0x74,0x90);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPolygonMesh,0x84D6D3CF,0xAB24,0x491C,0x9C,0xE3,0x47,0xB9,0xA8,0xCE,0xE3,0x10);


MIDL_DEFINE_GUID(IID, IID_IAcadRay,0xB8F2DD54,0x0AFB,0x4001,0x8E,0x90,0xEF,0x7C,0xAE,0xAF,0x85,0x14);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadRay,0x806E3509,0xED82,0x4B89,0xAC,0x1C,0x10,0xF2,0xFE,0xCD,0x67,0x44);


MIDL_DEFINE_GUID(IID, IID_IAcadShape,0xE2197D25,0x7B8A,0x46B6,0xAD,0x9E,0x78,0x90,0x2B,0xF7,0x0F,0x02);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadShape,0xE6A37037,0x9367,0x4BE1,0x98,0x32,0xD9,0xD3,0x63,0xD7,0xD6,0x4C);


MIDL_DEFINE_GUID(IID, IID_IAcadSolid,0x40B4259C,0xCD6F,0x48F5,0xA6,0x5D,0x44,0x92,0x01,0x71,0x69,0x5C);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSolid,0xA4236B96,0x6EB4,0x49AA,0x88,0xDC,0xE4,0x4E,0xE4,0x58,0xF8,0x1E);


MIDL_DEFINE_GUID(IID, IID_IAcadSpline,0x48F16A9E,0x62A2,0x4F18,0xB5,0x67,0x23,0xE7,0xFF,0xA7,0x00,0xDF);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSpline,0x0CD182D2,0x2865,0x4233,0x81,0x90,0x95,0xEE,0xC9,0xA7,0x99,0x97);


MIDL_DEFINE_GUID(IID, IID_IAcadText,0x06D87DCB,0xC57E,0x4EB1,0x87,0x0D,0x00,0xCE,0x26,0x96,0x1B,0x8E);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadText,0x90E52C50,0x7EF4,0x4DC1,0xBD,0xD0,0xE2,0xB8,0xD0,0xD3,0xE4,0xD3);


MIDL_DEFINE_GUID(IID, IID_IAcadTolerance,0xFBD0E340,0xBFBB,0x494E,0x8B,0x8E,0xFC,0xE5,0x1B,0x03,0xCA,0xB2);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadTolerance,0xFF10AB5B,0xC276,0x4FF6,0xA8,0x56,0xB4,0x0C,0x4C,0x34,0x89,0x77);


MIDL_DEFINE_GUID(IID, IID_IAcadTrace,0x534D33FB,0x13BF,0x46E8,0xB3,0xF1,0xB8,0xAF,0xA2,0x1E,0x41,0x56);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadTrace,0xB8C86F77,0x7A21,0x4448,0x85,0xE5,0x92,0xFE,0x27,0xA6,0x56,0x94);


MIDL_DEFINE_GUID(IID, IID_IAcadXline,0x103A15FD,0x2195,0x4701,0xB6,0xFF,0xA0,0xF3,0x35,0x5D,0xB2,0x5C);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadXline,0x9C8747C8,0x244B,0x42ED,0xB6,0x9F,0x15,0x36,0xD8,0x3E,0x85,0x04);


MIDL_DEFINE_GUID(IID, IID_IAcadPViewport,0x31E79643,0xC695,0x4F82,0x94,0xB4,0xBC,0xAB,0x62,0xD2,0x00,0xDA);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPViewport,0x37275283,0x1B95,0x48B9,0xA0,0xEE,0x1E,0x6D,0xFA,0x12,0x2E,0xBF);


MIDL_DEFINE_GUID(IID, IID_IAcadMInsertBlock,0x0D86F5A2,0x1749,0x4E36,0x96,0x23,0x73,0xD0,0x09,0xA8,0x52,0xC2);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadMInsertBlock,0xDC9F9832,0xEE66,0x400F,0x90,0x7F,0xB9,0x14,0x29,0x95,0xDF,0x17);


MIDL_DEFINE_GUID(IID, IID_IAcadPolyfaceMesh,0xC8139715,0x3C0E,0x4C5A,0x80,0xBE,0x33,0xE0,0x93,0x70,0x07,0x75);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPolyfaceMesh,0xAC051ABE,0x78EF,0x4D28,0x92,0xC3,0x3B,0x30,0x1E,0x90,0x97,0x06);


MIDL_DEFINE_GUID(IID, IID_IAcadMLine,0x665BACBB,0xD863,0x4C2A,0xA8,0xE3,0xF9,0xC5,0xC0,0x3C,0xDC,0x08);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadMLine,0x251A45DF,0x0CB6,0x4FB3,0xBD,0x02,0xC7,0x6B,0x3A,0x2A,0x1C,0x26);


MIDL_DEFINE_GUID(IID, IID_IAcadExternalReference,0x374AF9E8,0x2B30,0x4F34,0x9B,0xE0,0x0E,0x60,0xDF,0xF1,0xEC,0xF5);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadExternalReference,0xE327FDF3,0xACD6,0x4511,0xB7,0x17,0x56,0x21,0x54,0xE7,0x5C,0x25);


MIDL_DEFINE_GUID(IID, IID_IAcadTable,0x12CC3C8D,0xAE9E,0x4DFE,0xB9,0x85,0xC5,0x51,0x85,0x84,0x58,0xAA);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadTable,0x9F7166C6,0x2E46,0x427C,0x99,0x56,0xD2,0x60,0x1D,0x0C,0x15,0x36);


MIDL_DEFINE_GUID(IID, IID_IAcadOle,0xC0B342AA,0x44C2,0x4121,0x84,0x7A,0x3B,0x2A,0xED,0x88,0x08,0xD7);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadOle,0x62D2AB7D,0x473A,0x48FF,0xA4,0x07,0x90,0xB3,0xC2,0xAA,0xB7,0x60);


MIDL_DEFINE_GUID(IID, IID_IAcadHelix,0x54B8FA24,0x4971,0x4CC1,0xBD,0x9C,0xFB,0x3F,0xCA,0x98,0xE7,0xC5);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadHelix,0x70E321A0,0xF2A1,0x4B96,0x9F,0x9D,0x82,0x72,0xD6,0x7D,0x6C,0xC0);


MIDL_DEFINE_GUID(IID, IID_IAcadSurface,0x40CAE0C5,0xEE07,0x44A2,0xAF,0x05,0xA2,0xD9,0xCF,0x03,0x16,0x06);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSurface,0x0F7E0A1E,0x90C5,0x4043,0xA1,0x4E,0x49,0xD9,0xCC,0xCB,0xBC,0x01);


MIDL_DEFINE_GUID(IID, IID_IAcadPlaneSurface,0x196A47F4,0x9D29,0x4508,0xBC,0x0F,0x40,0x01,0x07,0x00,0x97,0xA1);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPlaneSurface,0x7A69115C,0x2631,0x4041,0x84,0x6A,0x9C,0x44,0x26,0xF8,0xC7,0x0C);


MIDL_DEFINE_GUID(IID, IID_IAcadExtrudedSurface,0x6BCEB5EE,0x126A,0x4813,0xA5,0x27,0x37,0x84,0xEE,0x4E,0x44,0xFC);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadExtrudedSurface,0xFF21C1A0,0xF55F,0x4F83,0xAA,0x07,0xFA,0x17,0xB1,0x9D,0xC5,0x54);


MIDL_DEFINE_GUID(IID, IID_IAcadRevolvedSurface,0xBDB86C98,0x7974,0x453A,0xBB,0xB9,0x65,0xAE,0xD1,0x89,0x70,0xA5);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadRevolvedSurface,0x17C28199,0x8C6A,0x477C,0x9B,0x1E,0x31,0xC6,0xE1,0xBB,0x17,0xF9);


MIDL_DEFINE_GUID(IID, IID_IAcadSweptSurface,0x04B7592D,0x6CEF,0x4537,0x8F,0x76,0x71,0x2F,0x64,0xD6,0xF4,0x2A);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSweptSurface,0x01051767,0x3175,0x4B06,0x81,0xCF,0xF8,0xF5,0xCE,0x3B,0x0D,0x2B);


MIDL_DEFINE_GUID(IID, IID_IAcadLoftedSurface,0x0585CAEB,0x38E3,0x453D,0xB2,0x6C,0x9E,0x17,0x8D,0xC4,0x5F,0x2B);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLoftedSurface,0xD3BB6333,0xB4CE,0x48DA,0xBF,0x1B,0x19,0x8E,0x9E,0x8B,0x95,0xAF);


MIDL_DEFINE_GUID(IID, IID_IAcadSection,0x96FEBB41,0xF125,0x4CC1,0x8F,0x09,0x1D,0xBB,0x51,0x4C,0xD2,0x1C);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSection,0x85668C5B,0x36EE,0x4DBE,0xB4,0xC6,0xA2,0xB4,0xD3,0xF3,0x91,0x64);


MIDL_DEFINE_GUID(IID, IID_IAcadSectionManager,0xA28DABB3,0xDDC0,0x4713,0xA9,0xE9,0x87,0xF0,0x3C,0xC9,0x2A,0xF1);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSectionManager,0xCC734C6C,0xD4EE,0x4D24,0xB6,0x88,0x0D,0xF9,0x9D,0xDC,0xCF,0xA5);


MIDL_DEFINE_GUID(IID, IID_IAcadUnderlay,0xA9B5B4BA,0x81F7,0x4F02,0x9C,0xC0,0x19,0xB5,0x24,0x52,0x3D,0xAA);


MIDL_DEFINE_GUID(IID, IID_IAcadDwfUnderlay,0x22FE4523,0xB650,0x4DB4,0xAD,0x11,0x93,0x3C,0x9C,0x5E,0x56,0xB1);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDwfUnderlay,0x7EC3558C,0xE1A0,0x4E0B,0x92,0xBD,0x17,0xCE,0xA1,0x90,0x2A,0x6B);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDgnUnderlay,0x6FA2D697,0x24E2,0x46EF,0x94,0x1E,0x15,0xD4,0x01,0x9C,0xDB,0x8A);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPdfUnderlay,0x2F256D6B,0x9FF7,0x4062,0xB7,0x13,0x4D,0xFD,0xE2,0x8C,0x4F,0xC9);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSubEntity,0x7692C10F,0x3AA7,0x4F73,0xBE,0x25,0x08,0x5A,0x18,0xA1,0x40,0x66);


MIDL_DEFINE_GUID(IID, IID_IAcadSubEntSolidFace,0xCBB27EFD,0x4292,0x4DFB,0x98,0xF9,0x95,0x93,0xE3,0xD7,0xBC,0x6C);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSubEntSolidFace,0x6EA4F0E3,0x5198,0x43EB,0x90,0xDD,0xA0,0x1C,0x48,0x08,0xEC,0x44);


MIDL_DEFINE_GUID(IID, IID_IAcadSubEntSolidEdge,0x15CF0663,0x0E86,0x4628,0xB9,0xFE,0xDE,0xD3,0x2A,0x22,0xFA,0x10);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSubEntSolidEdge,0x6D445A1D,0x718B,0x4C13,0x86,0xF8,0xF9,0x54,0x1E,0x20,0xE0,0xED);


MIDL_DEFINE_GUID(IID, IID_IAcadSubEntSolidVertex,0x7DDA2E7F,0x17B8,0x468B,0xA8,0xD6,0x3D,0xE0,0x66,0xB3,0xCB,0x4C);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSubEntSolidVertex,0xA9C5C44C,0xE820,0x44EE,0x8F,0xAA,0xD2,0x3F,0x5D,0x06,0xCE,0x80);


MIDL_DEFINE_GUID(IID, IID_IAcadSubEntSolidNode,0x2B120F0D,0x7F90,0x40E3,0xA9,0x1C,0x55,0x71,0x29,0x61,0x9D,0x2D);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSubEntSolidNode,0xE6FCE1EB,0x59C7,0x409A,0x9D,0xC3,0x0D,0x47,0x87,0xF3,0xD4,0x82);


MIDL_DEFINE_GUID(IID, IID_IAcadWipeout,0x62B2E053,0xC836,0x4513,0xB0,0x7E,0x22,0xC1,0xF8,0xE7,0x82,0x36);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadWipeout,0x264A30A0,0x3779,0x4244,0x85,0x8E,0xDF,0x0B,0xB3,0x1B,0x52,0x5C);


MIDL_DEFINE_GUID(IID, IID_IAcadSubDMesh,0x0198A43F,0x876E,0x418c,0xBF,0xDD,0x84,0x1E,0xD6,0x1B,0x88,0xE8);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSubDMesh,0xF1D4AB28,0xA403,0x4FFB,0xB7,0x3A,0x1F,0x67,0xDD,0xBE,0x69,0x6A);


MIDL_DEFINE_GUID(IID, IID_IAcadSubDMeshFace,0xB47B379F,0x4F9F,0x4347,0xBE,0x75,0xBC,0x06,0x2D,0x81,0x2C,0x99);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSubDMeshFace,0xF2136C59,0x8155,0x45D9,0xB0,0xFB,0xC5,0xA8,0xA8,0x84,0x64,0x7A);


MIDL_DEFINE_GUID(IID, IID_IAcadSubDMeshEdge,0x3BD0F0E6,0x3766,0x4aae,0xBD,0x35,0x1F,0xAC,0x7D,0x82,0x21,0x5D);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSubDMeshEdge,0xA0291F02,0xC52F,0x4521,0x92,0x5D,0x9B,0xED,0x61,0x01,0xD2,0xB5);


MIDL_DEFINE_GUID(IID, IID_IAcadSubDMeshVertex,0x8D839860,0x8124,0x4a1d,0xB2,0x15,0xCD,0x7B,0xE0,0xCF,0x71,0x20);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSubDMeshVertex,0xBA5E6315,0x1CCB,0x420A,0x89,0xE7,0xB2,0x0A,0x7C,0xF9,0xF8,0x22);


MIDL_DEFINE_GUID(IID, IID_IAcadDimension,0x70A7C241,0xF067,0x4BBA,0x8B,0x62,0x4A,0x69,0xB9,0xA0,0x88,0x45);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimension,0x3ACEB335,0x09B8,0x4843,0xBA,0x8C,0x15,0x03,0x6F,0x91,0xE5,0x55);


MIDL_DEFINE_GUID(IID, IID_IAcadDimAligned,0x528DF772,0xD0A1,0x4D34,0x95,0xA2,0xE6,0x43,0xE3,0x9A,0x65,0x37);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimAligned,0x5B1197B8,0xB852,0x4C5B,0xB9,0xB0,0xB0,0x4D,0x5D,0x1A,0x90,0x86);


MIDL_DEFINE_GUID(IID, IID_IAcadDimAngular,0xD7187777,0xA662,0x47E5,0x87,0x49,0x70,0xB9,0xB4,0x36,0xDE,0xF0);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimAngular,0xAD5078D0,0xC038,0x438A,0x8B,0x42,0xB1,0xF1,0x6A,0x6F,0xED,0x4C);


MIDL_DEFINE_GUID(IID, IID_IAcadDimDiametric,0x9C32E747,0x9CB2,0x4216,0xB6,0xB1,0x76,0x10,0x20,0x38,0x52,0x57);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimDiametric,0xB63A17A3,0x07C5,0x46F6,0xAB,0x22,0x98,0x1E,0xDF,0xD8,0x75,0xB8);


MIDL_DEFINE_GUID(IID, IID_IAcadDimOrdinate,0x9F56A92F,0x889B,0x46D5,0xB2,0x79,0x71,0xE3,0x5D,0x70,0x55,0x25);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimOrdinate,0xFA6D095A,0xA5A9,0x4C44,0xAA,0x07,0xFE,0xFC,0x8B,0x1D,0x29,0xCF);


MIDL_DEFINE_GUID(IID, IID_IAcadDimRadial,0x67809A55,0x363A,0x417B,0x92,0xD3,0x81,0x97,0x86,0x12,0xB1,0x59);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimRadial,0xBA31C14D,0xF408,0x405B,0x92,0x8A,0x19,0x2D,0xB5,0x6F,0x8C,0xCE);


MIDL_DEFINE_GUID(IID, IID_IAcadDimRotated,0x7E690BA9,0x20E9,0x4A12,0xB3,0x75,0x2B,0x51,0x9D,0x0A,0x15,0x90);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimRotated,0xE2AEE1D6,0x7BBB,0x4D6A,0x9B,0x96,0xD5,0x29,0xD5,0x6E,0x7C,0xCD);


MIDL_DEFINE_GUID(IID, IID_IAcadDim3PointAngular,0xF96FAC80,0x084D,0x4DAF,0x84,0xB5,0xF1,0x4F,0x1F,0x66,0x05,0xBA);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDim3PointAngular,0x37ACB9D6,0x9FA4,0x496E,0xA5,0x50,0xBA,0x1B,0x74,0xC3,0x1E,0x0A);


MIDL_DEFINE_GUID(IID, IID_IAcadDimArcLength,0x71F92DD9,0xE2A9,0x4358,0xA5,0x01,0xE1,0x3C,0xC8,0x9E,0x4B,0x64);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimArcLength,0x13F1081A,0x13C7,0x4AFC,0xB9,0xC2,0x56,0xAE,0x98,0xFA,0xDD,0x0C);


MIDL_DEFINE_GUID(IID, IID_IAcadDimRadialLarge,0x7388AF9F,0xEC79,0x4C46,0xAD,0x86,0xB5,0x9D,0x46,0x42,0x4A,0x48);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDimRadialLarge,0x1C9A43C5,0xE911,0x4B7B,0xBF,0xA0,0xD4,0xBD,0x9F,0x4B,0x4C,0xF0);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadBlock,0x63F062F5,0x44BD,0x4C7D,0xA1,0x42,0x28,0xCC,0xE3,0xEE,0xCE,0xB8);


MIDL_DEFINE_GUID(IID, IID_IAcadModelSpace,0x134A4D6B,0x1DC2,0x4539,0xA7,0xF0,0xE5,0xEB,0xC1,0x00,0x44,0x23);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadModelSpace,0x151FB9D2,0x38F4,0x456F,0x87,0x20,0x97,0xBB,0xEB,0xDB,0x82,0xA8);


MIDL_DEFINE_GUID(IID, IID_IAcadPaperSpace,0x76856FC9,0x8A8B,0x441E,0x8F,0xC3,0x0D,0xA5,0x29,0xCD,0x93,0x61);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadPaperSpace,0xAF65484D,0x9BC9,0x4C36,0xA4,0xE3,0x37,0xBD,0x3D,0x72,0x62,0x22);


MIDL_DEFINE_GUID(IID, IID_IAcadFileDependency,0x87C3D049,0xDE04,0x4966,0xB7,0x94,0x52,0x30,0x99,0x99,0x2E,0x06);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadFileDependency,0x490BE6CE,0xA6B5,0x4A45,0x92,0xCA,0x1D,0xA2,0x37,0x08,0x9A,0xE6);


MIDL_DEFINE_GUID(IID, IID_IAcadFileDependencies,0xD932B444,0x5E99,0x4739,0xB6,0x56,0x51,0x5A,0xA9,0xDA,0x3E,0xBE);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadFileDependencies,0x596CEF1D,0x2D7A,0x42FE,0x8F,0xC4,0x76,0xB0,0x87,0xBC,0xEB,0xDE);


MIDL_DEFINE_GUID(IID, IID_IAcadSummaryInfo,0xCEB19507,0xDE94,0x4A2B,0xA1,0xF0,0x1D,0x11,0xFE,0x35,0xC3,0x13);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSummaryInfo,0xEE7164EF,0x162A,0x4E90,0xBC,0x38,0x5E,0xA0,0x12,0x00,0xCF,0xF3);


MIDL_DEFINE_GUID(IID, IID_IAcadDatabasePreferences,0x2BF537C1,0x34DB,0x4840,0xA0,0x05,0xDE,0xFF,0x3D,0x44,0xFF,0xF9);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDatabasePreferences,0xDF0B47FD,0xEF47,0x42A5,0x8A,0xF0,0xF6,0x1B,0x04,0xB0,0xA9,0xD8);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadDatabase,0x41D36B39,0xB3AE,0x468D,0x8A,0xB8,0x04,0xCC,0x10,0x07,0xE0,0xF6);


MIDL_DEFINE_GUID(IID, IID_IAcadSecurityParams,0xE9385F39,0x80AB,0x4DA9,0x8E,0x6D,0x78,0x84,0x2B,0x8B,0xED,0x79);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadSecurityParams,0xD572547B,0x8F57,0x45CB,0x87,0x54,0x72,0xB1,0x60,0x6C,0x5D,0xAF);


MIDL_DEFINE_GUID(IID, IID_IAcadLayerStateManager,0x4648C336,0x6A3B,0x4C87,0x93,0xF4,0x3F,0x2A,0xCD,0x65,0xE9,0x5E);


MIDL_DEFINE_GUID(CLSID, CLSID_AcadLayerStateManager,0xC287AE4D,0xE7AC,0x49D0,0xAC,0x33,0x3E,0x76,0xB1,0x8F,0xAA,0x89);


MIDL_DEFINE_GUID(IID, IID_IAxDbDocumentEvents,0xB7E8F26C,0xEFF1,0x4DC9,0xAA,0x3D,0x5A,0x17,0xA0,0xA0,0xF7,0xA4);


MIDL_DEFINE_GUID(IID, IID_IAxDbDocument,0x13D9FE78,0x5155,0x483F,0x92,0x83,0xC9,0x41,0x03,0x4E,0x81,0x06);


MIDL_DEFINE_GUID(CLSID, CLSID_AxDbDocument,0xEBF0F8FD,0x632A,0x4AB8,0x8D,0x71,0xE7,0x72,0x17,0x89,0x87,0x47);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



