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
//----- TARXMySelectReactor.cpp : Implementation of TARXMySelectReactor
//-----------------------------------------------------------------------------
#include "StdAfx.h"
#include "TARXMySelectReactor.h"
#include <string.h>
TARXMySelectReactor::Holder TARXMySelectReactor::s_holder;
//-----------------------------------------------------------------------------
TARXMySelectReactor::TARXMySelectReactor (AcApDocument *pDoc) : AcEdSSGetFilter () {
	mpDoc =NULL ;
	if ( pDoc != NULL ) {
		mpDoc =pDoc ;
		addSSgetFilterInputContextReactor (mpDoc, this) ;
	}
}

//-----------------------------------------------------------------------------
TARXMySelectReactor::~TARXMySelectReactor () {
	Detach () ;
}

//-----------------------------------------------------------------------------
void TARXMySelectReactor::Attach () {
	Detach () ;
	mpDoc =acDocManager->curDocument () ;
	if ( mpDoc )
		addSSgetFilterInputContextReactor (mpDoc, this) ;
}

void TARXMySelectReactor::Detach () {
	if ( mpDoc ) {
		removeSSgetFilterInputContextReactor (mpDoc, this) ;
		mpDoc =NULL ;
	}
}
void TARXMySelectReactor::TARX_tselect()
{
	AcApDocument *pDoc =acDocManager->curDocument ();
	if (s_holder.dict.find(pDoc) == s_holder.dict.end())
		s_holder.dict.insert(std::make_pair(pDoc, new TARXMySelectReactor(pDoc)));
}
void TARXMySelectReactor::TARX_delselect()
{
	AcApDocument *pDoc =acDocManager->curDocument ();
	DocReactors::iterator pos = s_holder.dict.find(pDoc);
	if ( pos != s_holder.dict.end())
	{
		delete pos->second;
		s_holder.dict.erase(pos);
	}
}

//-----------------------------------------------------------------------------
void TARXMySelectReactor::ssgetAddFilter (
	int ssgetFlags,
	AcEdSelectionSetService &service,
	const AcDbObjectIdArray &selectionSet,
	const AcDbObjectIdArray &subSelectionSet
	) 
{
	acutPrintf(L"\n%s:ssgetFlags=%d,selectionSet.size()=%d, subSelectionSet.size()=%d", L"ssgetAddFilter\n"
		, ssgetFlags, selectionSet.length(), subSelectionSet.length());

	// Just do the subentity highlighting here, nothing else.
	// (No modification of the resulting selection set)
	//
	ads_name eName;
	AcDbObjectId id;

	for (int i = 0; i < subSelectionSet.length(); i++)
	{
		resbuf * rb = NULL;
		service.ssNameX(true, i, rb);

		if (NULL != rb)
		{
			AcDbObjectIdArray curIdPath;
			resbuf *rbWalk = rb;
			while (NULL != rbWalk)
			{
				if (RTENAME == rbWalk->restype)
				{
					eName[0] = rbWalk->resval.rlname[0];
					eName[1] = rbWalk->resval.rlname[1];
					if(Acad::eOk == acdbGetObjectId(id, eName))
						curIdPath.append(id);
				}
				rbWalk = rbWalk->rbnext;
			}
			// reverse the curIdPath order (required for highlighting)
			AcDbObjectIdArray reversedIdPath;
			for (int j = curIdPath.length() - 1; j >= 0; j--)
				reversedIdPath.append(curIdPath[j]);
			AcDbFullSubentPath fsp(reversedIdPath, AcDbSubentId());


			// Exempt AdskRings custom entity from highlighting, otherwise subselection will be overridden
			AcDbEntity *pEnt;
			wchar_t *cust_ent = L"AsdkRings";
			if (Acad::eOk == acdbOpenObject(pEnt, id, AcDb::kForRead))
			{
				if (_wcsicmp(cust_ent,pEnt->isA()->name()) == 0){
					pEnt->close();
					acutRelRb(rb);
					return;
				}
			}


			if (service.highlight(i, fsp) !=  Acad::eOk)
				acutPrintf(L"\nHighlighting failed!");
			pEnt->close();
			acutRelRb(rb);
		}
	}
}


void TARXMySelectReactor::ssgetRemoveFilter(
									   int ssgetFlags,
									   AcEdSelectionSetService &service,
									   const AcDbObjectIdArray& selectionSet,
									   const AcDbObjectIdArray& subSelectionSet,
									   AcDbIntArray& removeIndexes,
									   AcDbArrayIntArray& removeSubentIndexes)
{  
	acutPrintf(L"\n%s", L"ssgetRemoveFilter\n");
}

void TARXMySelectReactor::ssgetAddFailed(
									int ssgetFlags,
									int ssgetMode,
									AcEdSelectionSetService &service,
									const AcDbObjectIdArray& selectionSet,
									resbuf *rbPoints)
{  
	acutPrintf(L"\n%s", L"ssgetAddFailed\n");
}

void
TARXMySelectReactor::ssgetRemoveFailed(
									   int ssgetFlags,
									   int ssgetMode,
									   AcEdSelectionSetService &service,
									   const AcDbObjectIdArray& selectionSet,
									   resbuf *rbPoints,
									   AcDbIntArray& removeIndexes,
									   AcDbArrayIntArray& removeSubentIndexes)
{  
	acutPrintf(L"\n%s", L"ssgetRemoveFailed\n");
}

void
TARXMySelectReactor::endSSGet(
							  Acad::PromptStatus returnStatus,
							  int ssgetFlags,
							  AcEdSelectionSetService &service,
							  const AcDbObjectIdArray& selectionSet)
{  
	acutPrintf(L"\n%s", L"endSSGet\n");
}

void
TARXMySelectReactor::endEntsel(
							   Acad::PromptStatus       returnStatus,
							   const AcDbObjectId&      pickedEntity,
							   const AcGePoint3d&       pickedPoint,
							   AcEdSelectionSetService& service)
{  
	acutPrintf(L"\n%s", L"endEntsel\n");
}
