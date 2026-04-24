#!/usr/bin/env python3
import re
import sys
import zipfile
import subprocess
import tempfile
from pathlib import Path

# To Candidates: 
# This is just a utitlity script we have created for our own convience to automate the process of calling `git am 0001-some-patch.patch`
# We appreciate your dilligence, but verifying your patches apply cleanly via this script not part of our evaluation criteria, and you do not need to concern yourself with understanding the workings of this script. 

# Usage: 
# python3 apply_patches.py <SingKing_CodingTest_YourName_Patches.zip>
# 
# It creates a new branch named `candidate/<YourName>` from main, applies the patches in order, and leaves you on that branch if successful. 
# If any patch fails to apply, it aborts the process and deletes the branch to avoid leaving you in a broken state.
def die(msg, code=1):
    print(f"error: {msg}", file=sys.stderr)
    sys.exit(code)


def run(cmd, **kwargs):
    return subprocess.run(cmd, check=True, **kwargs)


def main():
    if len(sys.argv) != 2:
        die(f"usage: {sys.argv[0]} <SingKing_CodingTest_YourName_Patches.zip>")

    zip_path = Path(sys.argv[1])
    if not zip_path.exists():
        die(f"file not found: {zip_path}")

    match = re.fullmatch(r"SingKing_CodingTest_(.+)_Patches\.zip", zip_path.name)
    if not match:
        die(
            "filename must match SingKing_CodingTest_<Name>_Patches.zip, "
            f"got: {zip_path.name}"
        )

    candidate_name = match.group(1)
    branch = f"candidate/{candidate_name}"

    # Check branch doesn't already exist
    result = subprocess.run(
        ["git", "branch", "--list", branch], capture_output=True, text=True
    )
    if result.stdout.strip():
        die(f"branch '{branch}' already exists — delete it first to re-apply")

    with zipfile.ZipFile(zip_path) as zf:
        patch_names = sorted(
            n for n in zf.namelist()
            if n.endswith(".patch") and not Path(n).name.startswith("._")
        )
        if not patch_names:
            die("zip contains no .patch files")

        with tempfile.TemporaryDirectory() as tmpdir:
            tmp = Path(tmpdir)
            for name in patch_names:
                zf.extract(name, tmp)

            patch_paths = [str(tmp / name) for name in patch_names]

            print(f"Creating branch '{branch}' from main…")
            run(["git", "checkout", "-b", branch, "main"])

            try:
                for patch in patch_paths:
                    print(f"Applying {Path(patch).name}…")
                    run(["git", "am", patch])
            except subprocess.CalledProcessError:
                print("\nPatch failed — aborting and removing branch…", file=sys.stderr)
                subprocess.run(["git", "am", "--abort"])
                subprocess.run(["git", "checkout", "main"])
                subprocess.run(["git", "branch", "-D", branch])
                die("patch application failed; branch has been cleaned up")

    print(f"\nDone — {len(patch_names)} patch(es) applied to '{branch}'")


if __name__ == "__main__":
    main()
