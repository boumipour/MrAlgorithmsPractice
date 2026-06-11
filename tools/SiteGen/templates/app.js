// Syntax highlighting
if (window.hljs) {
  document.querySelectorAll("pre code").forEach(function (el) {
    window.hljs.highlightElement(el);
  });
}

// Copy-to-clipboard buttons
document.querySelectorAll("[data-copy]").forEach(function (btn) {
  btn.addEventListener("click", function () {
    var code = btn.parentElement.querySelector("code");
    if (!code) return;
    navigator.clipboard.writeText(code.innerText).then(function () {
      var original = btn.textContent;
      btn.textContent = "✓";
      setTimeout(function () { btn.textContent = original; }, 1200);
    });
  });
});
