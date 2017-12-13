﻿// Copyright (c) Microsoft Open Technologies, Inc.  All rights reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.IO.Packaging;

namespace DocumentFormat.OpenXml.Packaging
{
    /// <summary>
    /// Represents a collection of relationships that are obtained from the package.
    /// </summary>
    internal class PackageRelationshipPropertyCollection : RelationshipCollection
    {
        public Package BasePackage { get; set; }

        public PackageRelationshipPropertyCollection(Package package)
        {
            this.BasePackage = package;
            if (this.BasePackage == null)
            {
                throw new ArgumentNullException(nameof(BasePackage));
            }

            this.BasePackageRelationshipCollection = this.BasePackage.GetRelationships();
            this.Build();
        }

        internal override void ReplaceRelationship(Uri targetUri, TargetMode targetMode, string strRelationshipType, string strId)
        {
            this.BasePackage.DeleteRelationship(strId);
            this.BasePackage.CreateRelationship(targetUri, targetMode, strRelationshipType, strId);
        }

        internal override Package GetPackage()
        {
            return this.BasePackage;
        }
    }
}
