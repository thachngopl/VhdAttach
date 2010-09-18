﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VhdAttach {
    class ListViewVhdItem : ListViewItem {

        public ListViewVhdItem(string fileName) {
            this.FileName = fileName;

            var file = new FileInfo(fileName);
            base.Text = file.Name;

            try {
                if (file.Exists) {
                    if (file.IsReadOnly) {
                        this.ToolTipText = "File is read-only." + Environment.NewLine + fileName;
                        this.ImageIndex = 1;
                    } else {
                        this.ToolTipText = fileName;
                        this.ImageIndex = 0;
                    }
                } else {
                    this.ToolTipText = "File not found." + Environment.NewLine + fileName;
                    this.ImageIndex = 2;
                }
            } catch (Exception ex) {
                this.ToolTipText = ex.Message + Environment.NewLine + fileName;
                this.ImageIndex = 3;
            }
        }

        public string FileName { get; private set; }

    }
}
