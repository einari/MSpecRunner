ADDINS_DIR=/Applications/MonoDevelop.app/Contents/MacOS/lib/monodevelop/AddIns
TARGET_DIR=$ADDINS_DIR/MSpecRunner
echo Addins : $ADDINS_DIR
echo TargetDir : $TARGET_DIR
mkdir -p $TARGET_DIR
cp -v bin/debug/*.dll $TARGET_DIR