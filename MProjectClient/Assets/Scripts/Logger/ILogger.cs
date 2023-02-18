/*****************************************************************//**
 * \file   ILogger.h
 * \brief  Logger interface
 * 
 * \author dek0058
 * \date   2023-02-18
 *********************************************************************/
using System;
using System.Collections.Generic;

namespace mproject.logger {
    public interface ILogger {
        public LinkedList<Tuple<ELogLevel, String>> Logs { get; }
        public bool Empty => Logs.Count == 0;
        public void WriteLog(ELogLevel _level, String _msg);
        
    }
}