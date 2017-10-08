describe("template", function () {
    var objUnderTest;

    beforeEach(function (done) {
        require(["app/template"], function (template) {
            objUnderTest = template;
            done();
        });
    });

    it("empty template dont throw exception", function () {
        var result = objUnderTest.fill("");
        expect(result).toEqual("");
    });

    it("should fill template", function () {
        var result = objUnderTest.fill("this is {{ prop }}, and this is {{ not }}", { prop: "replaced" });
        expect(result).toEqual("this is replaced, and this is ");
    });
});
