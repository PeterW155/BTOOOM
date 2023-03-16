mergeInto(LibraryManager.library, {
  CallSite: function (info) {
    window.dispatchReactUnityEvent("CallSite", UTF8ToString(info));
  },
});