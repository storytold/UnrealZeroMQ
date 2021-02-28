
#if PLATFORM_WINDOWS && !defined(WINDOWS_PLATFORM_TYPES_GUARD)
    // NB(bt): Fixed for Windows builds
    // https://forums.unrealengine.com/development-discussion/c-gameplay-programming/1574811-solved-cannot-package-plugin-due-to-allowwindowsplatformtypes-h-not-being-found-by-the-build-tool
	#include <Windows/AllowWindowsPlatformTypes.h>
	#include "zmq_impl.hpp"
	#include <Windows/HideWindowsPlatformTypes.h>
#else
	#include "zmq_impl.hpp"
#endif

