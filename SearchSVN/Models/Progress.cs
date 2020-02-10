using System;
using System.Collections.Generic;
using System.IO;

namespace SVNHistorySearcher.Models
{
	public static class Progress
	{

		static int failedRequests = 0;
		static int totalWork = 0;
		static int finishedWork = 0;
		static string currentLogMessage = "";
		static List<Action<string>> onLogUpdate = new List<Action<string>>();
		static List<Action> onMajorChange = new List<Action>();

		static Stream errorLog = new FileStream(@"error.log", FileMode.Create, FileAccess.Write);
		static StreamWriter errorLogWriter = new StreamWriter(errorLog) { AutoFlush = true };

#if DEBUG
		static Stream debugLog = new FileStream(@"debug.log", FileMode.Create, FileAccess.Write);
		static StreamWriter debugLogWriter = new StreamWriter(debugLog) { AutoFlush = true };
#endif

		static int previousFailedRequests = 0;
		static int previousTotalWork = 0;
		static int previousFinishedWork = 0;

		static object _lock = new Object();

		const int mchange = 1;

		public static void Reset() {
			lock (_lock) {
				failedRequests = 0;
				totalWork = 0;
				finishedWork = 0;
				currentLogMessage = "";
				previousFailedRequests = 0;
				previousTotalWork = 0;
				previousFinishedWork = 0;

				RaiseChangeEvent();
				RaiseLogEvent();
			}
		}

		public static void ResetExceptLog() {
			lock (_lock) {
				failedRequests = 0;
				totalWork = 0;
				finishedWork = 0;
				previousFailedRequests = 0;
				previousTotalWork = 0;
				previousFinishedWork = 0;

				RaiseChangeEvent();
			}
		}


		public static void RegisterCallbackOnMajorChange(Action a) {
			lock (_lock) {
				onMajorChange.Add(a);
			}
		}

		public static void RegisterCallbackOnLogUpdate(Action<string> a) {
			lock (_lock) {
				onLogUpdate.Add(a);
			}
		}

		static void RaiseChangeEvent() {
			foreach (Action a in onMajorChange) {
				a();
			}
		}

		static void RaiseLogEvent() {
			foreach (var a in onLogUpdate) {
				a(currentLogMessage);
			}
		}



		public static void AddFailedRequest(int amount) {
			lock (_lock) {
				failedRequests += amount;
				if (failedRequests - previousFailedRequests >= mchange) {
					previousFinishedWork = failedRequests;
					RaiseChangeEvent();
				}
			}
		}

		public static void AddTotalWork(int amount) {
			lock (_lock) {
				totalWork += amount;
				if (totalWork - previousTotalWork >= mchange) {
					previousTotalWork = totalWork;
					RaiseChangeEvent();
				}
			}
		}

		public static void AddFinishedWork(int amount) {
			lock (_lock) {
				finishedWork += amount;
				if (finishedWork - previousFinishedWork >= mchange) {
					previousFinishedWork = finishedWork;
					RaiseChangeEvent();
				}
			}
		}

		public static void Log(string format, params object[] args) {
			lock (_lock) {
				currentLogMessage = String.Format(format, args);
				RaiseLogEvent();
			}
		}

		public static void ErrorLog(object message) {
			lock (_lock) {
				errorLogWriter.WriteLine(message);
			}
		}

		public static void ErrorLog(string format, params object[] args) {
			lock (_lock) {
				errorLogWriter.WriteLine(format, args);
			}
		}


		public static void DebugLog(object message) {
#if DEBUG
			lock (_lock) {
				debugLogWriter.WriteLine(message);
			}
#endif
		}

		public static void DebugLog(string format, params object[] args) {
#if DEBUG
			lock (_lock) {
				debugLogWriter.WriteLine(format, args);
			}
#endif
		}



		public static void AddFailedRequest() {
			AddFailedRequest(1);
		}

		public static void AddTotalWork() {
			AddTotalWork(1);
		}

		public static void AddFinishedWork() {
			AddFinishedWork(1);
		}



		public static string GetLogMessage() {
			lock (_lock) {
				return currentLogMessage;
			}
		}

		public static int GetFailedRequests() {
			lock (_lock) {
				return failedRequests;
			}
		}

		public static long GetFinishedWork() {
			lock (_lock) {
				return finishedWork;
			}
		}

		public static long GetTotalWork() {
			lock (_lock) {
				return totalWork;
			}
		}

		public static int GetProgressPercentage() {
			lock (_lock) {
				if (totalWork != 0) {
					int res = (int)(100 * ((double)finishedWork / totalWork));
					if (res < 0) {
						return 0;
					} else if (res > 100) {
						return 100;
					} else {
						return res;
					}
				} else {
					return 0;
				}
			}
		}
	}
}
