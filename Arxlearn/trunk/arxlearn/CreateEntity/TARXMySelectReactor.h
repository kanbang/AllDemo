// (C) Copyright 1990-2002 by Autodesk, Inc. 
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted, 
// provided that the above copyright notice appears in all copies and 
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting 
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC. 
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to 
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//

//-----------------------------------------------------------------------------
//----- TARXMySelectReactor.h : Declaration of the TARXMySelectReactor
//-----------------------------------------------------------------------------
#pragma once

#ifdef CREATEENTITY_MODULE
#define DLLIMPEXP __declspec(dllexport)
#else
//----- Note: we don't use __declspec(dllimport) here, because of the
//----- "local vtable" problem with msvc. If you use __declspec(dllimport),
//----- then, when a client dll does a new on the class, the object's
//----- vtable pointer points to a vtable allocated in that client
//----- dll. If the client dll then passes the object to another dll,
//----- and the client dll is then unloaded, the vtable becomes invalid
//----- and any virtual calls on the object will access invalid memory.
//-----
//----- By not using __declspec(dllimport), we guarantee that the
//----- vtable is allocated in the server dll during the ctor and the
//----- client dll does not overwrite the vtable pointer after calling
//----- the ctor. And, since we expect the server dll to remain in
//----- memory indefinitely, there is no problem with vtables unexpectedly
//----- going away.
#define DLLIMPEXP
#endif

//-----------------------------------------------------------------------------
#include "acssgetfilter.h"

//-----------------------------------------------------------------------------
//----- Note: Uncomment the DLLIMPEXP symbol below if you wish exporting
//----- your class to other ARX/DBX modules
class /*DLLIMPEXP*/ TARXMySelectReactor : public AcEdSSGetFilter {

protected:
	AcApDocument *mpDoc ;

public:
	TARXMySelectReactor (AcApDocument *pDoc =acDocManager->curDocument ()) ;
	virtual ~TARXMySelectReactor () ;

	virtual void Attach () ;
	virtual void Detach () ;
	virtual AcApDocument *Subject () const { return (mpDoc) ; }
	virtual bool IsAttached () const { return (mpDoc != NULL) ; }

	virtual void ssgetAddFilter (
		int ssgetFlags,
		AcEdSelectionSetService &service,
		const AcDbObjectIdArray &selectionSet,
		const AcDbObjectIdArray &subSelectionSet
	) ;

	virtual void
    ssgetRemoveFilter(
        int ssgetFlags,
        AcEdSelectionSetService &service,
        const AcDbObjectIdArray& selectionSet,
        const AcDbObjectIdArray& subSelectionSet,
        AcDbIntArray& removeIndexes,
        AcDbArrayIntArray& removeSubentIndexes);

    virtual void
    ssgetAddFailed(
        int ssgetFlags,
        int ssgetMode,
        AcEdSelectionSetService &service,
        const AcDbObjectIdArray& selectionSet,
        resbuf *rbPoints);

    virtual void
    ssgetRemoveFailed(
        int ssgetFlags,
        int ssgetMode,
        AcEdSelectionSetService &service,
        const AcDbObjectIdArray& selectionSet,
        resbuf *rbPoints,
        AcDbIntArray& removeIndexes,
        AcDbArrayIntArray& removeSubentIndexes);

    virtual void
    endSSGet(
        Acad::PromptStatus returnStatus,
        int ssgetFlags,
        AcEdSelectionSetService &service,
        const AcDbObjectIdArray& selectionSet);

    virtual void
    endEntsel(
        Acad::PromptStatus       returnStatus,
        const AcDbObjectId&      pickedEntity,
        const AcGePoint3d&       pickedPoint,
        AcEdSelectionSetService& service);

	static void TARX_tselect();
	static void TARX_delselect();
private:
	typedef std::map<AcApDocument*, TARXMySelectReactor*> DocReactors; 
	struct Holder
	{
		DocReactors dict;
		~Holder(){
			for (DocReactors::iterator itr(dict.begin()); itr != dict.end(); ++itr)
				delete itr->second;
		}
	};
	static  Holder s_holder;
} ;
